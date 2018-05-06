using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetBox : MonoBehaviour {
	public Transform Box;
	public Transform respawnPoint;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			Box.position=respawnPoint.position;
		}
	}

}
