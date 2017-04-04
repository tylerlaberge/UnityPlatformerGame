using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	
	public AudioClip clipBounce;
	public AudioClip clipRespawn;
	public AudioClip clipPunch; 
	public AudioClip clipPowerUp;
	public AudioClip clipPowerDown;
	public AudioClip clipCheckpoint;
	public AudioClip clipLevelEnd;
	
	private AudioSource audioBounce;
	private AudioSource audioRespawn;
	private AudioSource audioPunch;
	private AudioSource audioPowerUp;
	private AudioSource audioPowerDown;
	private AudioSource audioCheckpoint;
	private AudioSource audioLevelEnd;
	
	void Start () {
		this.audioBounce = this.createAudio(clipBounce);
		this.audioRespawn = this.createAudio(clipRespawn);
		this.audioPunch = this.createAudio(clipPunch);
		this.audioPowerUp = this.createAudio(clipPowerUp);
		this.audioPowerDown = this.createAudio(clipPowerDown);
		this.audioCheckpoint = this.createAudio(clipCheckpoint);
		this.audioLevelEnd = this.createAudio(clipLevelEnd);
	}
	
	private AudioSource createAudio(AudioClip clip) {
		AudioSource newAudio = this.gameObject.AddComponent<AudioSource>();
		newAudio.clip = clip;
		
		return newAudio;
	}
	
	public void playBounce() {
		this.audioBounce.Play();
	}
	
	public void playRespawn() {
		this.audioRespawn.Play();
	}
	
	public void playPunch() {
		this.audioPunch.Play();
	}
	
	public void playPowerUp() {
		this.audioPowerUp.Play();
	}
	
	public void playPowerDown() {
		this.audioPowerDown.Play();
	}
	
	public void playCheckpoint() {
		this.audioCheckpoint.Play();
	}
	
	public void playLevelEnd() {
		this.audioLevelEnd.Play();
	}
}
