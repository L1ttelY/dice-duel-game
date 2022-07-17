using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileHpBar:MonoBehaviour {

	TileControllerBase tile;
	[SerializeField] GameObject pointPrefab;
	Image[] points;


	private void Start() {
		tile=GetComponentInParent<TileControllerBase>();
		points=new Image[tile.hpMax];

		float center = (tile.hpMax-1)*0.5f;
		for(int i = 0;i<tile.hpMax;i++) {
			float delta = (i-center)*0.3f;
			points[i]=Instantiate(pointPrefab,transform).GetComponent<Image>();
			points[i].transform.localPosition=new Vector3(delta,0.55f);
		}

	}

	private void Update() {
		for(int i = 0;i<tile.hpMax;i++) {
			points[i].color=i<tile.hp ? Color.white : Color.gray*0.2f;
		}
	}

}