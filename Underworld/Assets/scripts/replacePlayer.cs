using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replacePlayer : MonoBehaviour {
	public GameObject water;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			water.GetComponent<waterRise> ().rise = false;
		}
	}
}
