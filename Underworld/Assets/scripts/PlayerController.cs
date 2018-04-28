using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
//
public class PlayerController : MonoBehaviour {
	private Rigidbody2D player;
	//private Animator anim;

	public float maxSpeed = 10f;
	public float jumpForce= 10f;

	bool facingRight = true;
	bool grounded=false;
	[SerializeField]
	private Transform groundCheck;
	float groundRadius=0.2f;
	public LayerMask whatIsGround;

	public Vector3 respawnPoint;

	void Start () {
		player = GetComponent<Rigidbody2D> ();

		respawnPoint=transform.position;
	}
	

	void FixedUpdate () {
		
		grounded=Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

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
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			//anim.SetBool("Ground",false);
			player.AddForce(new Vector2(0,jumpForce));
		}
	}
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Water"||other.tag=="FallCollider"){
			transform.position=respawnPoint;
			print(transform.position.x);
		}
		if(other.tag=="CheckPoint"){
			respawnPoint=other.transform.position;
		}

	}
}
