using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeBridge : MonoBehaviour {
	public GameObject[] bridges;
	private bool removeB = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(removeB){
			for(int i=0; i<bridges.Length;i++){
				bridges[i].GetComponent<BoxCollider2D>().enabled=false;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="BreakBridge"){
			removeB = true;
		}
	}
}
