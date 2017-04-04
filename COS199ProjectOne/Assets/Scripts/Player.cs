using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float bounceForce;
	public float horizForce;
	public float xVelocity;
	public float maxXVelocity;
	public float yMin;
	
	private Rigidbody rb;
	private Vector3 horizForceVector;
	private Vector3 respawnPoint;
	private float orig_bounce_force;
	
	private AudioManager audioManager;
	
	// Use this for initializationd
	void Start () {
		xVelocity = 0.0f;
		
		rb = GetComponent<Rigidbody>();
		horizForceVector = Vector3.zero;
		respawnPoint = this.transform.position;	
		orig_bounce_force = this.bounceForce;
		
		audioManager = FindObjectOfType<AudioManager>();		
	}
	
	void Respawn() {
		audioManager.playRespawn();
		
		horizForceVector.x = 0.0f;
		horizForceVector.y = 0.0f;
		rb.velocity = horizForceVector;
		
		this.transform.position = respawnPoint;
	}
	
	void Update()
	{
		if (this.transform.position.y < yMin) {
			Respawn();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			xVelocity = rb.velocity.x;
			if (xVelocity > -maxXVelocity) {
				xVelocity -= horizForce;
			}
			
			horizForceVector.x = xVelocity;
			horizForceVector.y = rb.velocity.y;
			rb.velocity = horizForceVector;
		} else  if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			xVelocity = rb.velocity.x;
			if (xVelocity < maxXVelocity) {
				xVelocity += horizForce;
			}
			
			horizForceVector.x = xVelocity;
			horizForceVector.y = rb.velocity.y;
			rb.velocity = horizForceVector;
		} 
	
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Checkpoint") {
			if (this.respawnPoint != other.gameObject.transform.position) {
				audioManager.playCheckpoint();
				this.respawnPoint = other.gameObject.transform.position;
			}
		}
		else if (other.gameObject.tag == "PowerUpBounce") {
			audioManager.playPowerUp();
			
			this.bounceForce *= 1.5f;
			Destroy(other.gameObject);
			Invoke("PowerUpBounceEnd", 5);
		}
		else if (other.gameObject.tag == "PowerUpScale") {
			audioManager.playPowerUp();
			
			this.transform.localScale *= 2;
			Destroy(other.gameObject);
			Invoke("PowerUpScaleEnd", 5);
		}
		else if (other.gameObject.tag == "PowerUpSpeed") {
			audioManager.playPowerUp();
			
			this.maxXVelocity *= 2;
			this.xVelocity *= 2;
			Destroy(other.gameObject);
			Invoke("PowerUpSpeedEnd", 5);
		}
	}
	
	void PowerUpBounceEnd() {
		audioManager.playPowerDown();
		
		this.bounceForce = this.orig_bounce_force;
	}
	
	void PowerUpScaleEnd() {
		audioManager.playPowerDown();
		
		this.transform.localScale /= 2;
	}
	
	void PowerUpSpeedEnd() {
		audioManager.playPowerDown();
		
		this.xVelocity /= 2;
		this.maxXVelocity /= 2;
	}
	
	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.tag == "Enemy") {
			audioManager.playPunch();
			Respawn();
		}
		else {
			audioManager.playBounce();
			
			ContactPoint contactPoint = collision.contacts[0];
			rb.AddForce(contactPoint.normal * bounceForce, ForceMode.Impulse);
			
		}
	}
}
