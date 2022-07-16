using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollingDiceController:MonoBehaviour {

	SpriteRenderer sprite;
	float timerThisFrame;
	int spriteIndex;

	public Vector2 targetPosition;

	[SerializeField] Sprite[] sprites;
	[SerializeField] float speed = 50;

	void Start() {
		sprite=GetComponent<SpriteRenderer>();
	}

	void Update() {

		transform.position=Vector3.MoveTowards(transform.position,targetPosition,Time.deltaTime*speed);
		timerThisFrame+=Time.deltaTime;
		bool arrived = (Vector2)transform.position==targetPosition;

		timerThisFrame+=Time.deltaTime;
		if(arrived) {
			if(timerThisFrame>0.5f) {
				Game.instance.DiceArrive(spriteIndex);
				Destroy(gameObject);
			}
		} else {
			if(timerThisFrame>0.1f) {
				timerThisFrame-=0.1f;
				spriteIndex=Random.Range(1,7);
				sprite.sprite=sprites[spriteIndex];
			}
		}

	}

}
