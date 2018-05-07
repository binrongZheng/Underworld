using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensorController : MonoBehaviour {
	public bool checkCtrl;
	public Transform briedge;
	public float moveDistance;
	public float moveVelocity;

	float pontPos;

	public bool moving;
	// Use this for initialization
	void Start () {
		checkCtrl=false;
		pontPos=briedge.position.y;

	}

	// Update is called once per frame
	void Update () {
		if(checkCtrl){
			if((transform.eulerAngles.z<=36)||(transform.eulerAngles.z>=324)){
				transform.Rotate(Vector3.back);
			}
			if(moveDistance>0){
				if(briedge.position.y<=pontPos+moveDistance){
					briedge.Translate(0,moveVelocity,0);
					moving=true;
				}
				else if(briedge.position.y<pontPos||briedge.position.y>pontPos+moveDistance){
					moving=false;
				}
			}
			else{
				if(briedge.position.y>=pontPos+moveDistance){
					briedge.Translate(0,-moveVelocity,0);
					moving=true;
				}
				else if(briedge.position.y>pontPos||briedge.position.y<pontPos+moveDistance){
					moving=false;
				} 
			}
		}
		else{
			if((transform.eulerAngles.z<=34)||(transform.eulerAngles.z>=323)){
				transform.Rotate(Vector3.forward);
			}
			if(moveDistance>0){
				if(briedge.position.y>=pontPos){
					briedge.Translate(0,-moveVelocity,0);
					moving=true;
				}
				else if(briedge.position.y<pontPos||briedge.position.y>pontPos+moveDistance){
					moving=false;
				} 
			}
			else{
				if(briedge.position.y<=pontPos){
					briedge.Translate(0,moveVelocity,0);
					moving=true;
				}
				else if(briedge.position.y>pontPos||briedge.position.y<pontPos+moveDistance){
					moving=false;
				} 

			}
		}
	}

}
