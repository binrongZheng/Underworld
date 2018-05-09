using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterRise : MonoBehaviour {
	public bool rise=false;
	private Vector3 initPos;
	// Use this for initialization
	void Start () {
		initPos=transform.position;
			
	}
	
	// Update is called once per frame
	void Update () {
		if(rise){
			transform.Translate(0,0.1f,0);
		}
		else{
			transform.position=initPos;
		}
	}
}
