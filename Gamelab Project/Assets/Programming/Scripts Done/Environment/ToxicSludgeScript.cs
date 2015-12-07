/* 7S_ToxicS_001
 * Toxic Sludge Script 
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class ToxicSludgeScript : MonoBehaviour {

	public PlayerHpScript playerHpScr;
	public PlayerStats playerStats;
	public int toxicDmg = 1;
	public float toxicDmgTimer = 1;
	public float moveSpeedDecrease = 2;

	private float toxicDmgTimerRes;
	private float toxicMoveSpeed;
	private float normalMoveSpeed;

	void Start() {
		toxicDmgTimerRes = toxicDmgTimer;
		normalMoveSpeed = playerStats.moveSpeed;
		toxicMoveSpeed = playerStats.moveSpeed / moveSpeedDecrease;
	}

	public void ToxicSpeed() {
		playerStats.moveSpeed = toxicMoveSpeed;
	}

	public void GetToxicDmg() {
		toxicDmgTimer -= Time.deltaTime;
		if (toxicDmgTimer <= 0) {
			playerHpScr.GetDmg(toxicDmg);
			toxicDmgTimer = toxicDmgTimerRes;
		}
	}

	public void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Player") {
			ToxicSpeed();
			GetToxicDmg();
		}
	}

	public void OnCollisionExit() {
		toxicDmgTimer = toxicDmgTimerRes;
		playerStats.moveSpeed = normalMoveSpeed;
	}
}