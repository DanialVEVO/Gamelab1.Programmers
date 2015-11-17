/* [no code]
 * Particle Destroyer Script
 * Scripted by Chantal
 */
using UnityEngine;
using System.Collections;

public class ParticleDestroyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ParticleDestroy();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ParticleDestroy () {
		Destroy(gameObject, GetComponent<ParticleSystem>().duration);
	}
}
