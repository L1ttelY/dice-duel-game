using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSoil:TileControllerBase {

	static int[] deathCount = new int[2];

	protected override void Start() {
		base.Start();
		deathCount=new int[2];
	}

	public override void OnDeath() {
		base.OnDeath();
		deathCount[ownerPlayer]++;
	}

	[RuntimeInitializeOnLoadMethod]
	static void SubscribeEvents() {
		Game.TurnStart+=Game_TurnStart;
	}

	private static void Game_TurnStart() {
		int p = Game.instance.playerInControl;
		PlayerController.players[p].diceCount+=deathCount[p];
		deathCount[p]=0;
	}

}