using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFallWall : MonoBehaviour {
	public GameObject Player;
	public float velocity;
	private bool die;
	private bool follow=false;
	private float dist;
	private Vector3 iniPos;

	// Use this for initialization
	void Start () {
		iniPos=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.GetComponent<PlayerController>().die&&!die){
			transform.position=iniPos;
			follow=false;
		}
		if(transform.position.y<-150) transform.position=new Vector3(transform.position.x,-150,0);
		dist=transform.position.x-Player.transform.position.x;
		if(dist<10){
			follow=true;
		}
		if(follow){
			if(dist>0){
				transform.Translate(-velocity,0,0);
			}
			else{
				transform.Translate(velocity,0,0);
			}

		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="FallWall"){
			die=true;
			transform.Translate(0,-3,0);
			this.GetComponent<PolygonCollider2D>().enabled=false;
		}
	}
}
