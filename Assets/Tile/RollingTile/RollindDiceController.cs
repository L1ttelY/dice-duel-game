using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollindDiceController:MonoBehaviour {

	SpriteRenderer sprite;
	[SerializeField] Sprite[] sprites;
	float time;


	void Start() {
		sprite=GetComponent<SpriteRenderer>();
		Game.GameStart+=Game_GameStart;
	}

	private void Game_GameStart() {
		Game.GameStart-=Game_GameStart;
		Destroy(gameObject);
	}

	void Update() {
		time+=Time.deltaTime;
		if(time>0.1f) {
			time-=0.1f;
			sprite.sprite=sprites[Random.Range(0,sprites.Length)];
		}
	}
}
