using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {
	public Transform Player;
	public GameObject[] Pinchos;

	public float velocity;

	private Vector3 replace;

	private float distance;
	private bool follow=false;
	private bool passed=false;
	private float dist;

	// Use this for initialization
	void Start () {
		replace=transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		dist=transform.position.x-Player.transform.position.x;
		if(dist<15&&dist>-15&&!passed){
			follow=true;
		}

		if(!passed && Player.GetComponent<PlayerController>().die){
			transform.position=replace;
			follow=false;
		}
		//limite

		for(int i=0;i<Pinchos.Length;i++){
			if(Pinchos[i].transform.position.y<-80){
				Pinchos[i].transform.position=new Vector3(Pinchos[i].transform.position.x,-80,0);
			}
		}

		distance=Player.position.x-transform.position.x;
		if(follow){
			if(distance>0){
				transform.Translate(velocity*Time.deltaTime,0,0);
			}
			else{
				transform.Translate(-velocity*Time.deltaTime,0,0);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Player"){
			if(!passed){
				follow=false;
				transform.position=replace;
			}
		}
		if(other.tag=="FallPincho"){
			for(int i=0;i<Pinchos.Length;i++){
				Pinchos[i].GetComponent<BoxCollider2D>().enabled=false;
				follow=true;
			}
		}
		if(other.tag=="Pincho"){
			follow=false;
			passed=true;
		}
		if(other.tag=="Interruptor"){
			transform.Translate(0,0.4f,0);
		}
	}

}
