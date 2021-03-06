using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckController : MonoBehaviour {
	public GameObject water;
	public bool haveAnotherControl;
	public GameObject anotherControl;
	public bool checkCtrl;
	public Transform briedge;
	public float moveDistance;

	float pontPos;

	public bool moving;

	// Use this for initialization
	void Start () {
		checkCtrl=false;
		pontPos=briedge.position.x;

	}

	// Update is called once per frame
	void Update () {
		
		if(checkCtrl){
			if(haveAnotherControl){
				anotherControl.GetComponent<CheckController>().checkCtrl=false;
				water.GetComponent<waterRise>().rise=true;
			}
			if((transform.eulerAngles.z<=36)||(transform.eulerAngles.z>=324)){
				transform.Rotate(Vector3.back);
			}
			if(moveDistance>0){
				if(briedge.position.x<=pontPos+moveDistance){
					briedge.Translate(1f*Time.deltaTime,0,0);
					moving=true;
				}
				else if(briedge.position.x<pontPos||briedge.position.x>pontPos+moveDistance){
					moving=false;
				} 
			}
			else{
				if(briedge.position.x>=pontPos+moveDistance){
					briedge.Translate(-1*Time.deltaTime,0,0);
					moving=true;
				}
				else if(briedge.position.x>pontPos||briedge.position.x<pontPos+moveDistance){
					moving=false;
				} 
			}
		}
		else{
			if((transform.eulerAngles.z<=34)||(transform.eulerAngles.z>=323)){
				transform.Rotate(Vector3.forward);
			}
			if(moveDistance>0){
				if(briedge.position.x>=pontPos){
					briedge.Translate(-1f*Time.deltaTime,0,0);
					moving=true;
				}
				else if(briedge.position.x<pontPos||briedge.position.x>pontPos+moveDistance){
					moving=false;
				} 
			}
			else{
				if(briedge.position.x<=pontPos){
					briedge.Translate(1f*Time.deltaTime,0,0);
					moving=true;
				}
				else if(briedge.position.x>pontPos||briedge.position.x<pontPos+moveDistance){
					moving=false;
				} 

			}
		}
	}

}
