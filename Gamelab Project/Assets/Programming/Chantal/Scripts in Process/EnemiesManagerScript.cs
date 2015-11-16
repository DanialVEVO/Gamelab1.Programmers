/* 7S_???_001
 * Keeping track of living&dead enemies Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesManagerScript: MonoBehaviour {
	
	public GameObject[] enemiePrefab;
	public List<GameObject> enemiesInGame = new List<GameObject>();
	public int[] enemiesAliveID;
	public Vector3[] enemiesPos;

	/* enemiesAlive IDs
	 * 0 = Dead
	 * 1 = enemy kind 1
	 * 2 = enemy kind 2
	 * 3 = enemy kind 3
	 */
	
	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void Start () {
		FillEnemiesInGameList();
		enemiesAliveID = new int[enemiesInGame.Count];
		enemiesPos = new Vector3[enemiesInGame.Count];
		FillVariables();
	}

	public void FillEnemiesInGameList () {
		foreach (Transform child in transform){
			if (child.tag == "Enemy"){
				enemiesInGame.Add(child.gameObject);
			}
		}
	}

	void FillVariables (){
		for (int i = 0; i < enemiesInGame.Count; i++){
			enemiesAliveID[i] = enemiesInGame[i].GetComponent<EnemyIdScript>().enemyID;
			enemiesPos[i] = enemiesInGame[i].transform.position;
		}
	}
	
	public void CheckAlive(){
		for (int i = 0; i < enemiesInGame.Count; i++){
			if (enemiesInGame[i] == null){
				enemiesAliveID[i] = 0;
			} else {
				enemiesAliveID[i] = enemiesInGame[i].GetComponent<EnemyIdScript>().enemyID;
			}
		}
	}
	
	public void DestroyDead(){
		for (int i = 0; i < enemiesAliveID.Length; i++){
			if (enemiesAliveID[i] == 0){
				Destroy(enemiesInGame[i]);
			} else if (enemiesInGame[i] == null){
				GameObject spawnedEnemy = Instantiate(enemiePrefab[enemiesAliveID[i] -1], enemiesPos[i], transform.rotation) as GameObject;
				spawnedEnemy.transform.SetParent(transform);
			}
		}
	}
}
