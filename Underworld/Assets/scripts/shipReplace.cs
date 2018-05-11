using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipReplace : MonoBehaviour {
	public GameObject player;
	public Transform checkPoint;
	public Transform finalPoint;
	public Vector3 respawnPoint;
	public bool restart;
	public bool replacePoint;
	public float restartHeight;
	public bool moveRight=false;
	// Use this for initialization
	void Start () {
		respawnPoint=transform.position;
		replacePoint=false;
	}

	// Update is called once per frame
	void Update () {
		if(moveRight){
			player.GetComponent<PlayerController>().canControl=false;
			transform.Translate(Vector3.right*Time.deltaTime*0.3f);
		}
		if(!player.GetComponent<PlayerController>().checkFinalPoint){
			if(player.GetComponent<PlayerController>().checkWaterPoint){
				respawnPoint=new Vector3(checkPoint.position.x,checkPoint.position.y-1,0);
			}
		}
		else{
			respawnPoint=new Vector3(finalPoint.position.x,finalPoint.position.y-1,0);
		}
		if(replacePoint||restart){
			transform.position=respawnPoint;
			replacePoint=false;
			restart=false;
			transform.rotation=Quaternion.identity;
		}

	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="FallCollider"){
			transform.position=respawnPoint;
		}
		if(other.tag=="WaterCheckPoint"){
			respawnPoint=new Vector3(other.transform.position.x,other.transform.position.y-1,0);
		}
		if(other.tag=="FinalPoint"){
			moveRight=true;
		}

	}

}
