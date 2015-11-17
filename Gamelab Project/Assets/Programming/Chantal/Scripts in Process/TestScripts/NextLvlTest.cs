using UnityEngine;
using System.Collections;

public class NextLvlTest : MonoBehaviour {
	public int nextLevelId;

	public void OnClick(){
		GameObject enemiesListInScene = GameObject.FindWithTag("Enemies List");
		Destroy(enemiesListInScene);
		nextLevelId++;
		Application.LoadLevel(nextLevelId);
	}
}
