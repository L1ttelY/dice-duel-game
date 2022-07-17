using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiceCountDisplay:MonoBehaviour {

	TextMeshProUGUI text;
	[SerializeField] PlayerController target;


	private void Start() {
		text=GetComponent<TextMeshProUGUI>();
	}
	private void Update() {
		text.text=$"x{target.diceCount}";

	}

}