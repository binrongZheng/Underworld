using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterRise : MonoBehaviour {
	public bool rise=false;
	public bool checkWaterPoint;
	public GameObject player;
	public Transform checkPoint;
	public Transform FinalCheckPoint;
	public GameObject[] CloseFallDetect;
	public Vector3 initPos;
	public float velocity;
	// Use this for initialization
	void Start () {
		initPos=transform.position;
			
	}
	
	// Update is called once per frame
	void Update () {
		if(!player.GetComponent<PlayerController>().checkFinalPoint){
			if(player.GetComponent<PlayerController>().checkWaterPoint){
				initPos=new Vector3(checkPoint.position.x,checkPoint.position.y-2,0);
			}
		}
		else{
			initPos=new Vector3(FinalCheckPoint.position.x,FinalCheckPoint.position.y-2,0);
		}
		if(transform.position.y<FinalCheckPoint.position.y+5){
			if(rise){
				transform.Translate(0,velocity*Time.deltaTime,0);
					for(int i=0;i<CloseFallDetect.Length;i++){
						if(CloseFallDetect [i].GetComponent<BoxCollider2D> ().enabled){
							CloseFallDetect [i].GetComponent<BoxCollider2D> ().enabled = false;
						}
					}
			}
			else{
				transform.position=initPos;
			}
		}
	}
}
