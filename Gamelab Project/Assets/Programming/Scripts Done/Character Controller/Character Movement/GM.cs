using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

	public	float 	moveSpeed;
	public	float 	forwardDis;

	
	void Update (){
		if(Input.GetButtonDown("Jump")){
			CursorShow();
		}
	}

	void CursorShow (){
		if(Cursor.visible == true){
			Cursor.visible = false;
		}
		else{ Cursor.visible = true;}
	}


}
