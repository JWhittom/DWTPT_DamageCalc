using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Default");
    }

	public void ExitGame()
    {
        Application.Quit();
    }

}
