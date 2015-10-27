/*
	Rewritten code using "Space Shooter" tutorial and "Mail Pilot" demonstration in class as references
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
	//PUBLIC INSTANCE VARIABLES
	public static int score; //NOTE: static = belongs to the class and not an instance of the class

	//PRIVATE INSTANCE VARIABLE
	Text _scoreText; //INSERT: PRIVATE?
	private Text _gameOverText;
//	private Text _RestartText;
//
//	private bool _gameOver;
//	private bool _restart;
//	private int _score; //score will always be a whole number
	// 
//	void Start () 
//	{
//		//booleans to ensure variables won't be called
//		_gameOverText = false;
//		_RestartText = false;
//		
//		//lavels are turned off
//		_gameOverText.text = "";
//		_RestartText.text = "";
//		
//		score = 0;
//		UpdateScore (); //calling this method
//	}

	// on first frame
	void Awake () 
	{
		_scoreText = GetComponent <Text> (); //component reference
		score = 0; //resets score to 0
	}
	
	// 
	void Update () 
	{
		_scoreText.text = "Score: " + score; //basic concatenation for the text variable to set the string and it's int value
	}

//	//method to update player's score
//	public void AddScore(int newScoreValue)
//	{
////		_score += newScoreValue; //score which is 0 will increment by newScoreValue
//		UpdateScore (); //display the new score
//	}
//	
//	//method to display the score
//	void UpdateScore()
//	{
////		_scoreText.text = "Score: " + _score; //set the score text property to the string
//	}
	
	//method to call game over
//	public void GameOver() // no parameters just call this function
//	{
//		//calling game over text and flag
//		_gameOverText.text = "Game Over!";
//		_gameOver = true;
//	}
}
