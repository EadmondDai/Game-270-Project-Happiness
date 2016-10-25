using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Created by Eadmond, 10.24.2016
// This script is used to control all the scene management and restart the game.

// This script is accessed by CameraMove script.
// This script is accessed by PlayerMove script.

public class MySceneManager : MonoBehaviour {

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
