using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/DiceData")]
public class DiceData:ScriptableObject {

	[field: SerializeField] public int patternCount { get; private set; }
	[SerializeField] [TextArea] string _pattern1;
	[SerializeField] [TextArea] string _pattern2;

	public bool[,] pattern1;
	public bool[,] pattern2;

	void OnEnable() {
		LoadPattern(ref pattern1,_pattern1);
		LoadPattern(ref pattern2,_pattern2);
	}

	void LoadPattern(ref bool[,] target,string source) {

		target=new bool[3,3];
		string[] splited = source.Split('\n');

		for(int x = 0;x<3;x++) {
			for(int y = 0;y<3;y++) {
				target[x,y]=splited[y][x]=='1';
			}
		}

	}

}
