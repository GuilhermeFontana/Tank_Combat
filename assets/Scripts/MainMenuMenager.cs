using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMenager : MonoBehaviour {

	public string Level1;
	public string Level2;
    public string Level3;

	private string levelSelect;
	private int timeSelect;

	void Start ()
	{
		levelSelect = Level2;
	}

	public void StartGame ()
	{
		SceneManager.LoadScene (levelSelect);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void SelectArena (int Arena)
	{
		if (Arena == 1) 
		{
			levelSelect=Level1;
		}
		if (Arena == 2) 
		{
			levelSelect=Level2;
		}
        if (Arena == 3)
        {
            levelSelect=Level3;
        }
	}

	public void SelectTime (int time)
	{
		if (time == 1) 
		{
			timeSelect=60;
		}
		if (time == 2) 
		{
			timeSelect=120;
		}

		PlayerPrefs.SetInt ("Time", timeSelect);
	}

}		