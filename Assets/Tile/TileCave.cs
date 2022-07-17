using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCave:TileControllerBase {

	static HashSet<TileCave> instances = new HashSet<TileCave>();

	protected override void Start() {
		base.Start();
		instances.Add(this);
	}
	protected override void OnDestroy() {
		base.OnDestroy();
		instances.Remove(this);
	}

	public bool attacked;

	public override void Damage() {
		base.Damage();
		attacked=true;
	}

	[RuntimeInitializeOnLoadMethod]
	static void SubscribeEvents() {
		Game.TurnStart+=Game_TurnStart;
	}

	private static void Game_TurnStart() {
		bool doBlock = false;
		int p = 1-Game.instance.playerInControl;
		foreach(var i in instances) {
			if(i.ownerPlayer!=p) continue;
			if(!i.attacked) continue;
			i.attacked=false;
			doBlock=true;
		}

		attackBlocked=doBlock;

	}
}