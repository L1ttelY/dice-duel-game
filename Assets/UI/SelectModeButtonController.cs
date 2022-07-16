using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectModeButtonController:MouseOver {

	[SerializeField] int type;

	private void Start() {
		Game.OverrideText+=Game_OverrideText;
		TileControllerBase.OverrideColor+=TileControllerBase_OverrideColor;
	}

	private void OnDestroy() {
		Game.OverrideText-=Game_OverrideText;
		TileControllerBase.OverrideColor-=TileControllerBase_OverrideColor;
	}

	private void Game_OverrideText() {
		if(!isMouseOver) return;
		if(Game.instance.currentState!=State.DecideDirection) return;
		Game.instance.text.text="Use your dice like this.";
	}

	private void TileControllerBase_OverrideColor(object _sender) {
		if(!isMouseOver) return;
		if(Game.instance.currentState!=State.DecideDirection) return;
		TileControllerBase sender = _sender as TileControllerBase;
		if(sender.ownerPlayer!=Game.instance.selectedPlayer) return;

		int dx = sender.x-Game.instance.selectedX+1;
		int dy = sender.y-Game.instance.selectedY+1;

		int selectedDice = Game.instance.rollResult;
		bool[,] pattern = type==0 ? Game.instance.diceDatas[selectedDice].pattern1 : Game.instance.diceDatas[selectedDice].pattern2;

		if(dx>=0&&dx<=2&&dy>=0&&dy<=2&&pattern[dx,dy]) {
			bool heal = sender.ownerPlayer==Game.instance.playerInControl;
			sender.image.color=heal ? Color.green : Color.red;
		}
	}

	private void Update() {
		transform.localScale=Vector3.one*(isMouseOver ? 1.1f : 1f);
	}

	protected override void OnClick() {
		if(Game.instance.currentState==State.DecideDirection) Game.instance.ModeClick(type);
	}

}
