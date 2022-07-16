using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileControllerBase:MouseOver {

	public int ownerPlayer { get; protected set; }
	public int x;
	public int y;
	public Image image { get; private set; }
	public int hp { get; protected set; }
	[field: SerializeField] public int hpMax { get; protected set; }

	public static event EventHandler OverrideColor;

	void Start() {
		image=GetComponent<Image>();
	}

	void Update() {
		if(Game.instance.currentState==State.Normal&&isMouseOver) transform.localScale=Vector3.one*1.1f;
		else transform.localScale=Vector3.one;

		image.color=Color.white;
		OverrideColor?.Invoke(this);
	}

	public virtual void Damage() {
		hp--;
		if(hp<=0) OnDeath();
	}

	public virtual void Heal() {
		hp++;
		if(hp>hpMax) hp=hpMax;
	}

	public virtual void Init(int ownerPlayer,int x,int y) {
		this.x=x;
		this.y=y;
		this.ownerPlayer=ownerPlayer;
		hp=hpMax;
	}

	public virtual void OnDeath() {
		PlayerController.players[ownerPlayer].Damage();
		Destroy(gameObject);
	}

	protected override void OnClick() {
		Game.instance.DiceClick(ownerPlayer,x,y);
	}

}