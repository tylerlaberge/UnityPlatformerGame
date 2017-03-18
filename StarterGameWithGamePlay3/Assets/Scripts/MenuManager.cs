using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MenuManager : MonoBehaviour {
	
	public GameManager gameManager;
	
	public GameObject mainMenuPanel;
	public GameObject hudPanel;
	public GameObject pausePanel;
	public Text scoreText;

	// Use this for initialization
	void Start () 
	{
		ShowMainMenu();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	private void ShowMainMenu()
	{
		hudPanel.SetActive(false);
		mainMenuPanel.SetActive(true);
		pausePanel.SetActive(false);
		
	}
	
	private void ShowHUDMenu()
	{
		hudPanel.SetActive(true);
		mainMenuPanel.SetActive(false);
		pausePanel.SetActive(false);
	}
	
	private void ShowPauseMenu()
	{
		hudPanel.SetActive(false);
		mainMenuPanel.SetActive(false);
		pausePanel.SetActive(true);
	}
	
	public void OnStartButtonPressed()
	{
		Debug.Log("OnStartButtonPressed");
		ShowHUDMenu();
		gameManager.StartNewGame();
	}
	
	public void OnScoresButtonPressed()
	{
		Debug.Log("OnScoresButtonPressed");
	}
	
	public void OnPauseButtonPressed()
	{
		gameManager.PauseGame();
		ShowPauseMenu();
	}
	
	public void SetScore(int score) 
	{
		scoreText.text = score.ToString();
	}
	
	public void OnResumeButtonPressed()
	{
		ShowHUDMenu();
		gameManager.ResumeGame();
	}
	
	public void OnQuitButtonPressed()
	{
		ShowMainMenu();
	}
}
