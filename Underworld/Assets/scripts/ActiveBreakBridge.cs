using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBreakBridge : MonoBehaviour {
	//public GameObject[] bridge;
	public Rigidbody2D[] bridge;


	private bool fall=false;
	// Use this for initialization
	void Start () {
		for(int i=0;i<bridge.Length;i++){
			bridge[i].GetComponent<Rigidbody2D>();
			bridge[i].isKinematic=true;
		};
	}
	
	// Update is called once per frame
	void Update () {
		if(fall){
			for(int i=0;i<bridge.Length;i++){
				bridge[i].isKinematic=false;
			};

		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			fall=true;
		}
	}
}
