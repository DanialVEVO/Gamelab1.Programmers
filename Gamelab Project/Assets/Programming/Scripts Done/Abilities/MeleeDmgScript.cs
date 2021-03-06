﻿/* 7S_DMG_001
 * DMG Script for Melee Weapons
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class MeleeDmgScript : KnockBackScript {
	
	public int dmg;
	public Animation attackAnim;
	public AudioClip attackSound;
	public GameObject attackParticle;

	public void GiveDmg(GameObject enemy) {
		enemy.GetComponent<AiHpScript>().GetDmg(dmg);
		attackAnim.Play();
		GetComponent<AudioSource>().PlayOneShot(attackSound);
		Instantiate(attackParticle, transform.position, Quaternion.identity);
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Enemy") {
			GiveDmg(coll.gameObject);
			KnockBack(coll);
		}
	}
}
