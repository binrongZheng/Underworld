using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeWater : MonoBehaviour {
	public GameObject water;
	public GameObject Pont;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"||other.tag=="Box"){
			water.GetComponent<waterRise>().rise=true;
		}
	}
}
