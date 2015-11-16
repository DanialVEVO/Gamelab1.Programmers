/* 7S_???_001
 * Keeping track of living enemies Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesManagerScriptB: MonoBehaviour {

	public GameObject enemie;
	public GameObject[] enemies;
	public bool[] enemiesAlive;
	public Vector3[] enemiesPos;

	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start () {
		enemiesAlive = new bool[enemies.Length];
		enemiesPos = new Vector3[enemies.Length];
		FillVariables();
	}

	void FillVariables (){
		for (int i = 0; i < enemies.Length; i++){
			enemiesAlive[i] = true;
			enemiesPos[i] = enemies[i].transform.position;
		}
	}

	public void CheckAlive(){
		for (int i = 0; i < enemies.Length; i++){
			if (enemies[i] == null){
				enemiesAlive[i] = false;
			} else {
				enemiesAlive[i] = true;
			}
		}
	}

	public void DestroyDead(){
		for (int i = 0; i < enemiesAlive.Length; i++){
			if (enemiesAlive[i] == false){
				Destroy(enemies[i]);
			} else if (enemies[i] == null){
				GameObject spawnedEnemy = Instantiate(enemie, enemiesPos[i], transform.rotation) as GameObject;
				spawnedEnemy.transform.SetParent(transform);
			}
		}
	}
}
