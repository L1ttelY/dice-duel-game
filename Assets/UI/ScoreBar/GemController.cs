using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController:MonoBehaviour {

	[SerializeField] PlayerController opponentPlayer;
	[SerializeField] Sprite activeSprite;
	[SerializeField] int index;
	Sprite inactiveSprite;
	SpriteRenderer spriteRenderer;

	private void Start() {
		spriteRenderer=GetComponent<SpriteRenderer>();
		inactiveSprite=spriteRenderer.sprite;
	}

	private void Update() {
		int score = 6-opponentPlayer.hp;
		spriteRenderer.sprite=score>index ? activeSprite : inactiveSprite;
	}

}