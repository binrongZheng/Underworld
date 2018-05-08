using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieReplace : MonoBehaviour {
	public GameObject player;
	Vector3 initPos;
	float dist;
	// Use this for initialization
	void Start () {
		initPos=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		dist=player.transform.position.x-transform.position.x;
		if(dist>-20&&dist<20){
			if(player.GetComponent<PlayerController>().die){
				transform.position=initPos;
			}
		}
	}
}
