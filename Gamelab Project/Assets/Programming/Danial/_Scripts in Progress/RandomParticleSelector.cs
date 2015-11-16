/* [no code]
 * Random Particle Selector Script
 * Scripted by Chantal
 */


using UnityEngine;
using System.Collections;

public class RandomParticleSelector : MonoBehaviour {

	public ParticleSystem[] comicParticle = new ParticleSystem[3];
	public int selectedInt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ParticleRandomizer (){
		selectedInt = Random.Range(0,3);
		print (selectedInt);
		Instantiate(comicParticle[selectedInt]);
	}

}
