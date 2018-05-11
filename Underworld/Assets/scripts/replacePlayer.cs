using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replacePlayer : MonoBehaviour {
	public GameObject water;
	public GameObject spider;
	public GameObject Pala;
	public GameObject ship;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			ship.GetComponent<shipReplace>().replacePoint=true;
			water.GetComponent<waterRise> ().rise = false;
			spider.GetComponent<finalSpider>().restart=true;
			Pala.GetComponent<CheckController>().checkCtrl=false;
		}

	}
}
