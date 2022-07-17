using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMountain:TileControllerBase {

	protected override void Start() {
		base.Start();
		Debug.Log("START");
		Game.TurnStart+=Game_TurnStart;
	}
	protected override void OnDestroy() {
		base.OnDestroy();
		Game.TurnStart-=Game_TurnStart;
	}

	int[,] hpPrev = new int[3,3];
	TileControllerBase[] pending = new TileControllerBase[10];

	private void Game_TurnStart() {
		PlayerController owner = PlayerController.players[ownerPlayer];
		if(Game.instance.playerInControl!=ownerPlayer) {

			//¿ªÊ¼
			for(int x = 0;x<3;x++) {
				for(int y = 0;y<3;y++) {
					if(owner.tiles[x,y]) hpPrev[x,y]=owner.tiles[x,y].hp;
					else hpPrev[x,y]=-1;
				}
			}

		} else {

			//½áÊø
			int cnt = 0;
			for(int x = 0;x<3;x++) {
				for(int y = 0;y<3;y++) {

					if(
						owner.tiles[x,y]&&
						owner.tiles[x,y].hp<hpPrev[x,y]&&
						(x!=this.x||y!=this.y)&&
						(Mathf.Abs(x-this.x)<=1&&Mathf.Abs(y-this.y)<=1)
					) {
						pending[cnt]=owner.tiles[x,y];
						cnt++;
					}

				}
			}

			if(cnt!=0) {
				int ind = Random.Range(0,cnt);
				Damage();
				pending[ind].Heal();
			}

		}

	}

}
