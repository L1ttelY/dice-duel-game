using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButtonController:MouseOver {

	private void Start() {
		Game.OverrideText+=Game_OverrideText;
	}
	private void OnDestroy() {
		Game.OverrideText-=Game_OverrideText;
	}

	private void Game_OverrideText() {
		if(!isMouseOver) return;
		if(Game.instance.currentState!=State.Normal) return;
		Game.instance.text.text="End you turn.";
	}

	protected override void OnClick() {
		if(Game.instance.currentState==State.Normal) Game.instance.EndTurn();
	}

}
