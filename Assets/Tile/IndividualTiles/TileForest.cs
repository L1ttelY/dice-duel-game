using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileForest:TileControllerBase {

	[SerializeField] Sprite spritePlus;

	protected override void Start() {
		base.Start();

		int cnt = 0;
		for(int x = 0;x<3;x++) {
			for(int y = 0;y<3;y++) {
				if(PlayerController.players[ownerPlayer].tiles[x,y].GetType()==GetType()) cnt++;
			}
		}
		if(cnt>=2) {
			hpMax++;
			hp++;
			GetComponent<SpriteRenderer>().sprite=spritePlus;
		}
	}

}