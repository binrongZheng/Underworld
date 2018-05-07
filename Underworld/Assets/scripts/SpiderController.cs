using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {
	public Transform Player;
	public GameObject[] Pinchos;
	public GameObject[] Interruptor;

	public float velocity;

	private Vector3 replace;

	private float distance;
	private bool follow=false;
	private bool passed=false;

	// Use this for initialization
	void Start () {
		replace=transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
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
				transform.Translate(velocity,0,0);
			}
			else{
				transform.Translate(-velocity,0,0);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
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
			for(int i=0;i<Interruptor.Length;i++){
				Interruptor[i].GetComponent<BoxCollider2D>().enabled=false;
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.tag=="Interruptor"){
			for(int i=0;i<Interruptor.Length;i++){
				Interruptor[i].GetComponent<BoxCollider2D>().enabled=true;
			}
		}
	}
}
