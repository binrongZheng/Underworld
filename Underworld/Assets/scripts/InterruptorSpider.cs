using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorSpider : MonoBehaviour {
	//public Transform pont;
	public Rigidbody2D[] controlObject;
	public GameObject Spider;
	public Transform player;
	private bool fall;
	private Vector3 fallPos;
	private float upPos;
	private Vector3[] ControlPos;
	private float initControlPos;
	private bool passed=false;
	// Use this for initialization
	void Start () {
		upPos = transform.position.y;
		ControlPos=new Vector3[controlObject.Length];
	
		for(int i=0;i<controlObject.Length;i++){
			controlObject[i].GetComponent<Rigidbody2D>().isKinematic=true;
			ControlPos[i]=controlObject[i].position;
			initControlPos=controlObject[i].position.x;
		}

	}

	// Update is called once per frame
	void Update () {
		if(player.GetComponent<PlayerController>().die){
			for(int i=0;i<controlObject.Length;i++){
				controlObject[i].position=ControlPos[i];
				controlObject[i].transform.rotation=Quaternion.identity;
				controlObject[i].velocity=Vector3.zero;
				controlObject[i].angularVelocity=0;
				controlObject[i].GetComponent<Rigidbody2D>().isKinematic=true;
				controlObject[i].GetComponent<BoxCollider2D>().enabled=true;

			}
		}
		for(int i=0;i<controlObject.Length;i++){
			if (player.position.x>initControlPos)
				passed=true;
			
		}

		if(fall&&!passed){
			for(int i=0;i<controlObject.Length;i++){
				controlObject[i].isKinematic=false;
				//button move
				if(transform.position.y>upPos-0.20f)
					transform.Translate(0,-0.01f,0);
			}
		}
		else{
			for(int i=0;i<controlObject.Length;i++){
				
				//button move
				if(transform.position.y<upPos)
					transform.Translate(0,0.01f,0);
			}
		}


	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"||other.tag=="Box"){
			fall=true;
			fallPos=transform.position;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.tag=="Player"||other.tag=="Box"){
			fall=false;
		}
	}
}
