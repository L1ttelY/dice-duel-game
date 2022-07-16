using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum State {
	Normal,
	Thrown,
	DecideDirection,
	End
}

public class Game:MonoBehaviour {

	[field: SerializeField] public TextMeshProUGUI text { get; private set; }

	public static Game instance;

	public int playerInControl;
	public State currentState;

	public DiceData[] diceDatas;
	[SerializeField] GameObject rollingDice;

	public static event Void OverrideText;
	public static event Void TurnStart;
	public static event Void RoundStart;

	void Start() {
		instance=this;

		PlayerController.players[playerInControl].diceCount++;
		TurnStart?.Invoke();
		RoundStart?.Invoke();

	}

	void Update() {
		if(currentState==State.DecideDirection) {
			text.text=$"Choose how your dice is used.";
		} else if(currentState==State.End) {
			text.text=$"Player {(winner==0 ? "A" : "B")} won!";
		} else if(currentState==State.Normal) {
			text.text=$"Player {(playerInControl==0 ? "A" : "B")} to move.";
		} else if(currentState==State.Thrown) {
			text.text=$"Wait for the dice.";
		}
		OverrideText?.Invoke();
	}

	public void EndTurn() {
		if(currentState!=State.Normal) return;
		playerInControl=1-playerInControl;
		PlayerController.players[playerInControl].diceCount++;
		TurnStart?.Invoke();
		if(playerInControl==0) RoundStart?.Invoke();
	}

	public int selectedPlayer { get; private set; }
	public int selectedX { get; private set; }
	public int selectedY { get; private set; }
	public void DiceClick(int player,int x,int y) {

		if(currentState!=State.Normal) return;
		
		if(PlayerController.players[playerInControl].diceCount<=0) return;
		PlayerController.players[playerInControl].diceCount--;

		currentState=State.Thrown;
		RollingDiceController dice = Instantiate(rollingDice,Vector3.zero,Quaternion.identity).GetComponent<RollingDiceController>();
		dice.targetPosition=PlayerController.players[player].tiles[x,y].transform.position;

		selectedPlayer=player;
		selectedX=x;
		selectedY=y;

	}

	public void ModeClick(int mode) {

		for(int dx = 0;dx<3;dx++) {
			for(int dy = 0;dy<3;dy++) {

				int cx = selectedX+dx-1;
				int cy = selectedY+dy-1;

				DiceData diceData = diceDatas[rollResult];
				if(mode==0) {
					if(!diceData.pattern1[dx,dy]) continue;
				} else {
					if(!diceData.pattern2[dx,dy]) continue;
				}

				if(cx<0||cx>2||cy<0||cy>2) continue;
				TileControllerBase tile = PlayerController.players[selectedPlayer].tiles[cx,cy];
				if(!tile) continue;


				if(selectedPlayer==playerInControl) tile.Heal();
				else tile.Damage();

			}
		}

		currentState=State.Normal;

	}

	public int rollResult { get; private set; }
	public void DiceArrive(int result) {
		if(currentState!=State.Thrown) return;
		currentState=State.DecideDirection;
		rollResult=result;
	}

	int winner;
	public void GameEnd(int winner) {
		currentState=State.End;
		this.winner=winner;
	}

}
