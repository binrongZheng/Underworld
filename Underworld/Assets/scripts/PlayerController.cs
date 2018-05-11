﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//
//
public class PlayerController : MonoBehaviour {
	public bool canControl=false;
	public GameObject ship;
	public GameObject waterCheckCollision;
	public GameObject water;
	public bool checkWaterPoint=false;	
	public bool checkFinalPoint=false;	
	public GameObject interruptorAscensor;
	private Rigidbody2D player;
	//private Animator anim;
	//[SerializeField]
	public GameObject[] palas;
	public Transform LadderCenter;

	public float maxSpeed = 20f;
	public float jumpForce= 10f;

	bool facingRight = true;
	bool grounded=false;
	bool breakGrounded=false;

	bool LliscaGrounded=false;
	[SerializeField]
	private Transform groundCheck;
	[SerializeField]
	private Transform headCheck;
	float groundRadius=0.2f;
	public LayerMask whatIsGround;
	public LayerMask whatIsBGround;
	public LayerMask whatLliscaGround;
	public LayerMask whatIsTouch;

	public Vector3 respawnPoint;

	private bool palaControl=false;
	private bool playerMovePont=false;
	private bool llisca=false;
	public bool die=false;
	private bool ladder=false;
	private bool fallWater=false;
	private float checkWaterHeight;
	void Start () {
		player = GetComponent<Rigidbody2D> ();

		respawnPoint=transform.position;
	}
	

	void FixedUpdate () {
		
		grounded=Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		breakGrounded=Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsBGround);
		LliscaGrounded=Physics2D.OverlapCircle (groundCheck.position, groundRadius+0.2f, whatLliscaGround);
		die=Physics2D.OverlapCircle (headCheck.position, groundRadius, whatIsTouch);

		//anim.setBool ("Ground,grounded");
		//anim.setFloat("vSpeed",rigidbody2D.velocity.y);


		//anim.SetFloat ("Speed", Mathf.Abs (move));
		if(canControl){
			if(ladder){
				player.isKinematic=true;
				float move =Input.GetAxis("Vertical");
				player.velocity = new Vector2 (player.velocity.x,move*maxSpeed);
			}
			else{
				player.isKinematic=false;
			}
			if (grounded||breakGrounded)
				llisca = false;
			if (!llisca) {
				float move = Input.GetAxis ("Horizontal");
				player.velocity = new Vector2 (move*maxSpeed,player.velocity.y);

				if (move > 0 && !facingRight)
					Flip ();
				else if (move < 0 && facingRight)
					Flip ();
			}
		}
	}

	void Update(){
		checkWaterHeight=waterCheckCollision.transform.position.y-ship.transform.position.y;
		if(fallWater){
			player.velocity = new Vector2 (player.velocity.x,-0.1f);

		}
		if (die) {
			transform.position=respawnPoint;
			ship.GetComponent<shipReplace>().restart=true;
			if(checkWaterPoint){
				water.GetComponent<waterRise>().rise=true;
			}
			die = false;

		}
		if (LliscaGrounded) {
			
			llisca = true;
			//anim.SetBool("Ground",false);

			if (Input.GetKeyDown (KeyCode.Space)) {
				player.AddForce (new Vector2 (0, jumpForce));
			} 
			else {
				player.AddForce(new Vector2(1,0));
			}
			//player.velocity = new Vector2 (jumpForce,-0.75f);
			//player.AddForce(new Vector2(jumpForce,0));
		}
		if (canControl&& grounded && Input.GetKeyDown (KeyCode.Space)||breakGrounded && Input.GetKeyDown (KeyCode.Space)) {
			//anim.SetBool("Ground",false);
			//if(fallWater)	player.AddForce(new Vector2(0,jumpForce*1.1f));
			player.AddForce(new Vector2(0,jumpForce));
		}
		if (palaControl && Input.GetKeyDown (KeyCode.LeftControl)) {
			for(int i=0;i<palas.Length;i++){
				//assegurar que esta dentro del area
				if(i==3){
					if(interruptorAscensor.GetComponent<InterruptorController>().needPassedPoint){
						interruptorAscensor.GetComponent<InterruptorController>().needPassedPoint=false;
					}
					else{
						interruptorAscensor.GetComponent<InterruptorController>().needPassedPoint=true;
					}
				}
				if (transform.position.x-palas[i].transform.position.x>-10&&transform.position.x-palas[i].transform.position.x<10){
					if(palas[i].GetComponentInChildren<CheckController>().checkCtrl==true){
						palas[i].GetComponentInChildren<CheckController>().checkCtrl=false;}
					else
						palas[i].GetComponentInChildren<CheckController>().checkCtrl=true;
				}
			}
		}
		if(playerMovePont){
			
			for(int i=0;i<palas.Length;i++){
				if(i!=3){
					if(palas[i].GetComponentInChildren<CheckController>().checkCtrl==true){
						if(palas[i].GetComponentInChildren<CheckController>().moving==true){
							
							player.AddForce(new Vector2(30,0));
						}
					}
					else{
						if(palas[i].GetComponentInChildren<CheckController>().moving==true){
							player.AddForce(new Vector2(-30,0));
						}
					}
				}
			}
		}
		if(/*checkFinalPoint||*/!canControl){
			player.transform.Translate(Vector3.right*Time.deltaTime*0.3f);
		}
	}
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Water"||other.tag=="FallCollider"||other.tag=="Pincho"||other.tag=="FallPincho"||other.tag=="Enemy"){
			die=true;
			fallWater=false;
			transform.position=respawnPoint;
		}
		if(other.tag=="WaterFallCollider"){
			fallWater=true;
		}

		if(other.tag=="CheckPoint"){
			canControl=true;
			if(!checkWaterPoint)
			respawnPoint=other.transform.position;
		}

		if(other.tag=="FinalPoint"){
			respawnPoint=other.transform.position;
			checkFinalPoint=true;

		}
		if(other.tag=="RestartPoint"){
			SceneManager.LoadScene("level_1");
		}
		if(other.tag=="WaterCheckPoint"){
			if(checkWaterHeight<1){
				respawnPoint=other.transform.position;
				waterCheckCollision.GetComponent<BoxCollider2D>().enabled=false;
				checkWaterPoint=true;
			}
		}

		if(other.tag=="Pala"){
			palaControl=true;
		}
		if(other.tag=="MovePlatform"){
			playerMovePont=true;
		}
		if(other.tag=="Ladder"){
			ladder=true;
			transform.position=new Vector3(LadderCenter.position.x,transform.position.y,0);
		}

	}
	void OnTriggerExit2D(Collider2D other){
		if(other.tag=="Pala"){
			palaControl=false;
		}
		if(other.tag=="MovePlatform"){
			playerMovePont=false;
		}
		if(other.tag=="Ladder"){
			ladder=false;
		}
		if(other.tag=="WaterFallCollider"){
			fallWater=false;
		}
	}
}
