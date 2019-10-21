using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenager : MonoBehaviour {


	public Text blueScoreText;
	public Text redScoreText;



	// Use this for initialization
	void Start () 
	{
		blueScoreText.text = "Player 1: " + PlayerPrefs.GetInt ("BlueScore"); 
		redScoreText.text = "Player 2: " + PlayerPrefs.GetInt ("RedScore");
	}
}