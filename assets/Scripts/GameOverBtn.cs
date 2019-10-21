using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBtn : MonoBehaviour {

	public string mainmenu;
	
	public void MainMenuButt ()
	{
		SceneManager.LoadScene (mainmenu);
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
}
