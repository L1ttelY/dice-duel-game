using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController:MonoBehaviour {

	[SerializeField] GameObject endTurn;
	[SerializeField] GameObject selectMode1;
	[SerializeField] GameObject selectMode2;
	void Update() {
		endTurn.SetActive(Game.instance.currentState==State.Normal);
		if(Game.instance.currentState==State.DecideDirection) {
			selectMode1.SetActive(true);
			selectMode2.SetActive(Game.instance.diceDatas[Game.instance.rollResult].patternCount>1);
		} else {
			selectMode1.SetActive(false);
			selectMode2.SetActive(false);
		}

	}

}
