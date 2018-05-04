using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
//
public class PlayerController : MonoBehaviour {
	private Rigidbody2D player;
	//private Animator anim;
	//[SerializeField]
	public GameObject[] palas;

	public float maxSpeed = 10f;
	public float jumpForce= 10f;

	bool facingRight = true;
	bool grounded=false;
	bool LliscaGrounded=false;
	[SerializeField]
	private Transform groundCheck;
	float groundRadius=0.2f;
	public LayerMask whatIsGround;
	public LayerMask whatLliscaGround;

	public Vector3 respawnPoint;

	private bool palaControl=false;
	private bool playerMovePont=false;
	void Start () {
		player = GetComponent<Rigidbody2D> ();

		respawnPoint=transform.position;
	}
	

	void FixedUpdate () {
		
		grounded=Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		LliscaGrounded=Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatLliscaGround);

		//anim.setBool ("Ground,grounded");
		//anim.setFloat("vSpeed",rigidbody2D.velocity.y);
		float move = Input.GetAxis ("Horizontal");

		//anim.SetFloat ("Speed", Mathf.Abs (move));

		player.velocity = new Vector2 (move*maxSpeed,player.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Update(){
		if (LliscaGrounded) {
			//anim.SetBool("Ground",false);
			player.velocity = new Vector2 (jumpForce,0);
			//player.AddForce(new Vector2(jumpForce,0));
		}
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			//anim.SetBool("Ground",false);
			player.AddForce(new Vector2(0,jumpForce));
		}
		if (palaControl && Input.GetKeyDown (KeyCode.LeftControl)) {
			for(int i=0;i<palas.Length;i++){
				if(palas[i].GetComponentInChildren<CheckController>().checkCtrl==true)
					palas[i].GetComponentInChildren<CheckController>().checkCtrl=false;
				else
					palas[i].GetComponentInChildren<CheckController>().checkCtrl=true;
			}
		}
		if(playerMovePont){
			
			for(int i=0;i<palas.Length;i++){
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
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Water"||other.tag=="FallCollider"||other.tag=="Pincho"){
			transform.position=respawnPoint;
		}
		if(other.tag=="MovePlatform"){
			respawnPoint=other.transform.position;
		}

		if(other.tag=="CheckPoint"){
			respawnPoint=other.transform.position;
		}

		if(other.tag=="Pala"){
			palaControl=true;
		}
		if(other.tag=="MovePlatform"){
			playerMovePont=true;
		}

	}
	void OnTriggerExit2D(Collider2D other){
		if(other.tag=="Pala"){
			palaControl=false;
		}
		if(other.tag=="MovePlatform"){
			playerMovePont=false;
		}
	}
}
