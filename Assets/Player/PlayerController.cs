using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController:MonoBehaviour {

	public static PlayerController[] players = new PlayerController[2];

	[SerializeField] GameObject[] tilePrefabs;
	[SerializeField] int playerIndex;
	public TileControllerBase[,] tiles = new TileControllerBase[3,3];
	public int diceCount;
	public int hp { get; private set; }

	void Start() {

		players[playerIndex]=this;
		hp=6;

		for(int x = 0;x<3;x++) {
			for(int y = 0;y<3;y++) {

				tiles[x,y]=Instantiate(tilePrefabs[Random.Range(0,tilePrefabs.Length)],transform).GetComponent<TileControllerBase>();
				tiles[x,y].transform.localPosition=new Vector2((x-1)*1.6f,(y-1)*1.6f);
				tiles[x,y].Init(playerIndex,x,y);

			}
		}

	}

	void Update() {

	}

	public void Damage() {
		hp--;
		if(hp<=0) Game.instance.GameEnd(1-playerIndex);
	}

}
