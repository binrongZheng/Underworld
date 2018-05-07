using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	
	// Update is called once per frame
	void Update () {
		transform.position=new Vector3(target.position.x+7.5f,target.position.y+1f,target.position.z-15) ;
	}
}
