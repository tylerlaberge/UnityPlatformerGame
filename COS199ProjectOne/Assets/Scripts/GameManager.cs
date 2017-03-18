using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	public MenuManager menuManager;
	
	private bool running = false;
	private int score;
	private int levelNum = 0;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	public void StartNewGame() 
	{
		Debug.Log("StartNewGame");
		score = 0;
		running = true;
		LoadNextLevel();
	}
	
	public void PauseGame()
	{
		Debug.Log("PauseGame");
		running = false;
	}
	
	public void ResumeGame()
	{
		Debug.Log("Resume");
		running = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (running) {
			menuManager.SetScore(score++);
		}
	}
	
	public void LoadNextLevel()
	{
		SceneManager.LoadScene(getNextLevelName());
	}
	
	private string getNextLevelName()
	{
		levelNum++;
		return "level" + levelNum;
	}
}
