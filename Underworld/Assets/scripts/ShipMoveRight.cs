using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoveRight : MonoBehaviour {

	private bool moveRight=true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(moveRight){
			transform.Translate(Time.deltaTime*Vector3.right*0.3f);
		}	
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="CheckPoint"){
			moveRight=false;
		}
	}
}
