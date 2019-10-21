using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenagerScript : MonoBehaviour {

	//var que recebem as referencias da UI
	public Text timeText;
	public Text blueScoreText;
	public Text redScoreText;

	public int initialTime;
	public float timeBetweenAmmoSpawns;

	public int player1Score;							//var que armazena a pontuação do Player1 (AZUL)
	public int player2Score;							//var que armazena a pontuação do Player2

	public Transform[] spawnPointsLocations;
	public GameObject ammoPickup;

	//var qur recebem as referenciaas dos players
	public GameObject player1;
	public GameObject player2;

	public ParticleSystem boxAmmo;

    public GameObject instPanel;

	// Use this for initialization
	void Start () 
	{
		initialTime = PlayerPrefs.GetInt ("Time");
		player1Score = 0;
		player2Score = 0;
		InvokeRepeating ("DescreaseTime", 1.0f, 1.0f);
		InvokeRepeating ("SpawnAmmo", timeBetweenAmmoSpawns, timeBetweenAmmoSpawns);
		timeText.text = "Time: " + initialTime.ToString ();
        Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		redScoreText.text = "Player1 Score: " + player1Score.ToString ();
		blueScoreText.text = "Player2 Score: " + player2Score.ToString();

		//Debug.Log (player1Score);
		//Debug.Log (player2Score);

		if (initialTime <= 0) 
		{
			PlayerPrefs.SetInt("RedScore", player2Score);
			PlayerPrefs.SetInt("BlueScore", player1Score);

			CancelInvoke ();

			SceneManager.LoadScene("GameOver"); 
		}
	}

	//função que muda a pontuação do player1
	public void AddPlayer1Score ()
	{
		player1Score++;		
	}

	//função que muda a pontuação do player2
	public void AddPlayer2Score ()
	{
		player2Score++;
	}

	public void DescreaseTime ()
	{
		initialTime--;
		timeText.text = "Time: " + initialTime.ToString ();
	}

	public void SpawnAmmo()
	{
		int temp = Random.Range (0, spawnPointsLocations.Length);
		Instantiate (ammoPickup, spawnPointsLocations [temp].transform.position, spawnPointsLocations [temp].transform.rotation);

		//instancia caixa
		Instantiate (boxAmmo, spawnPointsLocations [temp].transform.position, spawnPointsLocations [temp].transform.rotation);

	}

    public void ClosePanel()
    {
        instPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
