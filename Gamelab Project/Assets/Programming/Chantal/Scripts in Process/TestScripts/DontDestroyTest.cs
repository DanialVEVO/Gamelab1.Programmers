using UnityEngine;
using System.Collections;

public class DontDestroyTest : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}
}
