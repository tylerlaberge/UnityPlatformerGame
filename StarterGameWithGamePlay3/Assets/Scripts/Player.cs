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
	
	
	// Use this for initializationd
	void Start () {
		rb = GetComponent<Rigidbody>();
		horizForceVector = Vector3.zero;
		xVelocity = 0.0f;
		respawnPoint = this.transform.position;
		audioSource = GetComponent<AudioSource>();
	}
	
	public void setRespawnPoint(Vector3 position) {
		this.respawnPoint = position;
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
	
	void OnCollisionEnter(Collision collision) 
	{
		// Only add jump force if the collision normal is straight up
		ContactPoint contactPoint = collision.contacts[0];
		
		rb.AddForce(contactPoint.normal * bounceForce, ForceMode.Impulse);
		
		audioSource.PlayOneShot(bounce);
	}

}
