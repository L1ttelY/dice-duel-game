using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCastle:TileControllerBase {
	protected override void Start() {
		base.Start();
		Game.TurnStart+=Game_TurnStart;
	}
	protected override void OnDestroy() {
		base.OnDestroy();
		Game.TurnStart-=Game_TurnStart;
	}

	private void Game_TurnStart() {
		if(Game.instance.playerInControl!=ownerPlayer) return;
		for(int _ = 0;_<1000;_++) {
			int x = Random.Range(0,3);
			int y = Random.Range(0,3);
			TileControllerBase target = PlayerController.players[1-ownerPlayer].tiles[x,y];
			if(target) {
				target.Damage();
				break;
			}
		}
	}
}
