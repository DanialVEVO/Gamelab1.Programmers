﻿/* 7S_SAL_001
 * Save and Load Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadGameScript : MonoBehaviour {

	private PlayerHpScript playerHpScr;
	private AbilitySwitchScript abilitySwitchScr;
	private ManaScript manaScr;
	private EnemiesManagerScript enemiesManagerScr;
	private PlayerManager playerManagerScr;
	private Pickup pickupScr;

	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}

	void FindObjects(){
		playerHpScr = GameObject.Find("testplayer").GetComponent<PlayerHpScript>();
		abilitySwitchScr = GameObject.Find("AbilitySwitch").GetComponent<AbilitySwitchScript>();
		manaScr = GameObject.Find("Mana Bar").GetComponent<ManaScript>();
		enemiesManagerScr = GameObject.Find("enemyManager").GetComponent<EnemiesManagerScript>();
		playerManagerScr = GameObject.Find("name").GetComponent<PlayerManager>();
		pickupScr = GameObject.Find("name").GetComponent<Pickup>();
	}

	public void SaveGame () {
		FindObjects();
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");
		GameData data = new GameData();

		data.levelID = Application.loadedLevel;
		data.enemies = enemiesManagerScr.enemiesAliveID;
		enemiesManagerScr.CheckAlive();
		data.collectables =  pickupScr.maxPickupCount;
		data.abilities = abilitySwitchScr.abilityUnlocked;
		data.playerHP = playerHpScr.curHP;
		data.playerLevens = playerHpScr.life;
		data.playerMana = manaScr.manaValue;
		data.playerPositionX = playerManagerScr.checkpoint.position.x;
		data.playerPositionY = playerManagerScr.checkpoint.position.y;
		data.playerPositionZ = playerManagerScr.checkpoint.position.z;

		bf.Serialize(file, data);
		file.Close();
	}

	public void LoadGame () {
		if (File.Exists(Application.persistentDataPath + "/PlayerData.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
			GameData data = (GameData) bf.Deserialize(file); 

			Application.LoadLevel(data.levelID);
			FindObjects();
			enemiesManagerScr.enemiesAliveID = data.enemies;
			enemiesManagerScr.DestroyDead();
			pickupScr.maxPickupCount = data.collectables;
			abilitySwitchScr.abilityUnlocked = data.abilities;
			abilitySwitchScr.SetAbilitieSpr();
			abilitySwitchScr.GetAbilityImg();
			playerHpScr.curHP = data.playerHP;
			playerHpScr.life = data.playerLevens;
			manaScr.manaValue = data.playerMana;
			transform.position = new Vector3(data.playerPositionX, data.playerPositionY, data.playerPositionZ);

			file.Close();
		}
	}
}
