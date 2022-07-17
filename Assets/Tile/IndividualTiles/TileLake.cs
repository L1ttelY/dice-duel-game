using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLake : TileControllerBase{
	protected override void Start() {
		base.Start();
		Game.RoundStart+=Game_RoundStart;
	}
	public override void OnDeath() {
		base.OnDeath();
		Game.RoundStart-=Game_RoundStart;
	}

	int cnt = 0;
	private void Game_RoundStart() {
		cnt++;
		if(cnt>=2){
			Heal();
			cnt-=2;
		}
	}
}