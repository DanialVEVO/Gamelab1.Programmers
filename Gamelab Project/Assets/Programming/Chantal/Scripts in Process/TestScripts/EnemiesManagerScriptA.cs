/* 7S_???_001
 * Keeping track of living enemies Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesManagerScriptA : MonoBehaviour {

	public List<int> livingEnemieID = new List<int>();
	public List<GameObject> livingEnemies = new List<GameObject>();
	public Vector3[] enemySpawnSpot;

	void Start () {
		FillLivingEnemiesIDList();
	}

	void Update () {
		RemoveDeadEnemyFromList();
	}

	public void SpawnEnemies(){
		FillLivingEnemiesList();

		for (int i = 0; i < livingEnemieID.Count;i++){
			GameObject spawnedEnemy = Instantiate(livingEnemies[i], enemySpawnSpot[i], transform.rotation) as GameObject;
			spawnedEnemy.transform.SetParent(transform);
			//Instantiate(livingEnemies[i], enemySpawnSpot[livingEnemieID[i]], transform.rotation);
		}
	}

	public void FillLivingEnemiesList () {
		foreach (Transform child in transform){
			if (child.tag == "Enemy"){
				livingEnemies.Add(child.gameObject);
			}
		}
	}

	public void FillLivingEnemiesIDList () {
		FillLivingEnemiesList();

		for (int i = 0; i < livingEnemies.Count; i++){
			int enemyID = livingEnemies[i].GetComponent<EnemyIdScript>().enemyID;
			livingEnemieID.Add(enemyID);
		}
	}
	
	public void RemoveDeadEnemyFromList () {
		for(var i = livingEnemies.Count - 1; i > -1; i--){
			if (livingEnemies[i] == null){
				livingEnemieID.RemoveAt(i);
				livingEnemies.RemoveAt(i);
			}
		}
	}
}
