using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetBridge : MonoBehaviour {
	public GameObject[] bridges;
	private Vector3[] initPos;
	private bool reset=false;
	private bool touchBriedge=false;
	// Use this for initialization
	void Start () {
		initPos=new Vector3[bridges.Length];
		for(int i=0;i<bridges.Length;i++){
			initPos[i]=bridges[i].transform.position;
		}
		/*for(int i=0;i<bridge.Length;i++){
			bridge[i].GetComponent<Rigidbody2D>();
			bridge[i].isKinematic=true;
		};*/

	}
	
	// Update is called once per frame
	void Update () {
		if(reset){
			for(int i=0;i<bridges.Length;i++){
				bridges[i].GetComponentInChildren<ActiveBreakBridge>().fall=false;

				bridges[i].transform.position=initPos[i];
				bridges[i].transform.rotation= Quaternion.identity;

				bridges[i].GetComponent<Rigidbody2D>().velocity=Vector3.zero;

				bridges[i].GetComponent<Rigidbody2D>().angularVelocity=0;
				bridges[i].GetComponent<Rigidbody2D>().isKinematic=true;

				//bridges[i].velocity=Vector3.zero;
				//bridges[i].angularVelocity=0;
				//bridges[i].isKinematic=true;

			}
			reset=false;
		}
		if(!touchBriedge) reset=false;
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="BreakBridge"){
			touchBriedge=true;
		}
		if(other.tag=="Player"){
			reset=true;
		}

	}
	void OnTriggerExit2D(Collider2D other){
		if(other.tag=="BreakBridge"){
			touchBriedge=false;
		}
	}
}
