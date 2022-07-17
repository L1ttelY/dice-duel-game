using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCave:TileControllerBase {

	static bool[] recentDeath = new bool[2];

	protected override void Start() {
		base.Start();
		recentDeath=new bool[2];
	}

	public override void OnDeath() {
		base.OnDeath();
		recentDeath[ownerPlayer]=true;
	}

	[RuntimeInitializeOnLoadMethod]
	static void SubscribeEvents() {
		Game.TurnStart+=Game_TurnStart;
	}

	private static void Game_TurnStart() {
		int p = 1-Game.instance.playerInControl;
		attackBlocked=recentDeath[p];
		recentDeath[p]=false;
	}
}