using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieReplace : MonoBehaviour {
	public GameObject player;
	private Vector3 iniPos;
	private float dist;
	// Use this for initialization
	void Start () {
		iniPos=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		dist=player.transform.position.x-transform.position.x;
		if(dist>-10&&dist<10){
			if(player.GetComponent<PlayerController>().die){
				print("hola");
				transform.position=iniPos;
			}
		}
	}
}
