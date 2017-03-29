using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public AudioClip bounce;
	public float bounceForce;
	public float horizForce;
	public float xVelocity;
	public float maxXVelocity;
	
	private Rigidbody rb;
	private Vector3 horizForceVector;
	
	public float yMin;
	private AudioSource audioSource;
	
	private Vector3 respawnPoint;
	
	private float orig_bounce_force;
	
	// Use this for initializationd
	void Start () {
		rb = GetComponent<Rigidbody>();
		horizForceVector = Vector3.zero;
		xVelocity = 0.0f;
		respawnPoint = this.transform.position;
		audioSource = GetComponent<AudioSource>();
		
		orig_bounce_force = this.bounceForce;
	}
	
	void Respawn() {
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
			this.respawnPoint = other.gameObject.transform.position;
		}
		else if (other.gameObject.tag == "PowerUpBounce") {
			this.bounceForce *= 1.5f;
			Destroy(other.gameObject);
			Invoke("PowerUpBounceEnd", 5);
		}
		else if (other.gameObject.tag == "PowerUpScale") {
			this.transform.localScale *= 2;
			Destroy(other.gameObject);
			Invoke("PowerUpScaleEnd", 5);
		}
		else if (other.gameObject.tag == "PowerUpSpeed") {
			this.maxXVelocity *= 2;
			this.xVelocity *= 2;
			Destroy(other.gameObject);
			Invoke("PowerUpSpeedEnd", 5);
		}
	}
	
	void PowerUpBounceEnd() {
		this.bounceForce = this.orig_bounce_force;
	}
	
	void PowerUpScaleEnd() {
		this.transform.localScale /= 2;
	}
	
	void PowerUpSpeedEnd() {
		this.xVelocity /= 2;
		this.maxXVelocity /= 2;
	}
	
	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.tag == "Enemy") {
			collision.gameObject.GetComponent<Enemy>().playAudio();
			Respawn();
		}
		else {
			// Only add jump force if the collision normal is straight up
			ContactPoint contactPoint = collision.contacts[0];
			rb.AddForce(contactPoint.normal * bounceForce, ForceMode.Impulse);
			
			audioSource.PlayOneShot(bounce);
		}
		
	}

}
