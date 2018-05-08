using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensorController : MonoBehaviour {
	public bool checkCtrl;
	public GameObject interruptor;
	// Use this for initialization
	void Start () {
		checkCtrl=false;
	}

	// Update is called once per frame
	void Update () {
		
		if(interruptor.GetComponent<InterruptorController>().needPassedPoint){
			if((transform.eulerAngles.z<=36)||(transform.eulerAngles.z>=324)){
				transform.Rotate(Vector3.back);
			}

		}
		else{
			if((transform.eulerAngles.z<=34)||(transform.eulerAngles.z>=323)){
				transform.Rotate(Vector3.forward);
			}
		}
	}

}
