using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void PlayScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
	
	public void Menu(int sceneIndex) {
		SceneManager.LoadScene(sceneIndex);
	}
	
	public void Exit() {
		Application.Quit();
	}
}
