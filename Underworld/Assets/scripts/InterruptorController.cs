using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorController : MonoBehaviour {
	public bool canUse=true;
	public Transform[] controlObject;
	public bool directionX;
	public float[] controlDist;
	public bool needPassedPoint;
	public float moveVelocity;

	public Transform player;
	private bool fall;
	private Vector3 fallPos;
	private float upPos;
	private float[] ControlPos;
	private float initControlPos;
	public bool passed=false;
	// Use this for initialization
	void Start () {
		upPos = transform.position.y;
		ControlPos=new float[controlObject.Length];
		if(directionX){
			for(int i=0;i<controlObject.Length;i++){
				ControlPos[i]=controlObject[i].position.x;
			}
		}
		else{
			for(int i=0;i<controlObject.Length;i++){
				ControlPos[i]=controlObject[i].position.y;
				initControlPos=controlObject[i].position.x;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
			if(!needPassedPoint) passed=false;
			else{

				for(int i=0;i<controlObject.Length;i++){
					if(directionX){
						if (player.position.x>ControlPos[i]-0.5f)
							passed=true;
					}
					else{
						if (player.position.x>initControlPos-0.5f)
							passed=true;
					}
				}
			}
			if (directionX){
				if(fall&&!passed){
					for(int i=0;i<controlObject.Length;i++){
					if(canUse){
						if(controlDist[i]<0){
							if(controlObject[i].position.x>ControlPos[i]+controlDist[i])
								controlObject[i].Translate(-moveVelocity,0,0);
						}
						else{
							if(controlObject[i].position.x<ControlPos[i]+controlDist[i])
								controlObject[i].Translate(moveVelocity,0,0);
						}
					}
					//interruptor movement
						if(transform.position.y>upPos-0.20f)
							transform.Translate(0,-0.01f,0);
					}
				}
				else{
					for(int i=0;i<controlObject.Length;i++){
					if(canUse){
						if(controlDist[i]<0){
							if(controlObject[i].position.x<ControlPos[i])
								controlObject[i].Translate(moveVelocity,0,0);
						}
						else{
							if(controlObject[i].position.x>ControlPos[i])
								controlObject[i].Translate(-moveVelocity,0,0);
						}
					}
						if(transform.position.y<upPos)
							transform.Translate(0,0.01f,0);
					}
				}
			}
			else{
				if(fall&&!passed){
					for(int i=0;i<controlObject.Length;i++){

					if(canUse){
						if(controlDist[i]<0){
							if(controlObject[i].position.y>ControlPos[i]+controlDist[i]){
								
								controlObject[i].Translate(0,-moveVelocity,0);
							}
						}
						else{
							if(controlObject[i].position.y<ControlPos[i]+controlDist[i]){
								
								controlObject[i].Translate(0,moveVelocity,0);
							}
						}
					}
						//button move
						if(transform.position.y>upPos-0.20f)
							transform.Translate(0,-0.01f,0);
					}
				}
				else{
					for(int i=0;i<controlObject.Length;i++){
					if(canUse){
						if(controlDist[i]<0){
							if(controlObject[i].position.y<ControlPos[i])
								controlObject[i].Translate(0,moveVelocity,0);
						}
						else{
							if(controlObject[i].position.y>ControlPos[i])
								controlObject[i].Translate(0,-moveVelocity,0);
						}
					}
						//button move
						if(transform.position.y<upPos)
							transform.Translate(0,0.01f,0);
					}
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
		if(other.tag=="Player"||other.tag=="Box"){//&&other.tag=="Box"){
			fall=false;
		}
	}
}
