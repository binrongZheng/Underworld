using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBreakBridge : MonoBehaviour {
	//public GameObject[] bridge;
	public Rigidbody2D[] bridge;

	public bool fall=false;

	// Use this for initialization
	void Start () {
		
		for(int i=0;i<bridge.Length;i++){
			bridge[i].isKinematic=true;

		};
	}
	
	// Update is called once per frame
	void Update () {
		if(fall){
			//print("fall");
			for(int i=0;i<bridge.Length;i++){
				bridge[i].isKinematic=false;

			};

		}
		else{
			for(int i=0;i<bridge.Length;i++){
				bridge[i].velocity=Vector3.zero;
				bridge[i].angularVelocity=0;
				bridge[i].isKinematic=true;
			};
		}

	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			fall=true;
		}
	}
}
