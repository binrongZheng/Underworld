using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replace : MonoBehaviour {
	public Vector3 respawnPoint;
	public bool replacePoint;
	// Use this for initialization
	void Start () {
		respawnPoint=transform.position;
		replacePoint=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(replacePoint){
			transform.position=respawnPoint;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="FallCollider"){
			transform.position=respawnPoint;
		}
	}
}
