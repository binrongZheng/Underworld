using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterRise : MonoBehaviour {
	public bool rise=false;
	public GameObject[] CloseFallDetect;
	private Vector3 initPos;
	public float velocity;
	// Use this for initialization
	void Start () {
		initPos=transform.position;
			
	}
	
	// Update is called once per frame
	void Update () {
		if(rise){
			transform.Translate(0,velocity*Time.deltaTime,0);
			for(int i=0;i<CloseFallDetect.Length;i++){
				CloseFallDetect [i].GetComponent<BoxCollider2D> ().enabled = false;
			}
		}
		else{
			transform.position=initPos;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Interruptor") {
			//velocity = 0.01f;
		}
	}
}
