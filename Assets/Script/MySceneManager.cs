using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Created by Eadmond, 10.24.2016
// This script is used to control all the scene management and restart the game.
// This script is able to change different requirement for each level.

// This script is accessed by CameraMove script.
// This script is accessed by PlayerMove script.

public class MySceneManager : MonoBehaviour {

    // Something wrong with these variables. 
    // Started from this one.
    public int CurrentLevel = 0;

    //public int NextLevelToGo
    //{
    //    get { return _NextLevelToGo; }
    //    set {
    //        //Debug.Log(System.Environment.StackTrace);
    //        _NextLevelToGo = value;
    //          }
    //}
    //public int _NextLevelToGo;

    //public int DebugValue = 0;

    private string LevelNameBase = "Level ";

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {

        //if ( SceneManager.GetSceneByName(LevelNameBase + CurrentLevel.ToString()) != null)
        //{
        string LevelName = SceneManager.GetActiveScene().name;

        if(LevelName == LevelNameBase + 1)
        {
            SceneManager.LoadScene(LevelNameBase + "2");
        }else if(LevelName == LevelNameBase + 2)
        {
            SceneManager.LoadScene(LevelNameBase + "3");
        }else if (LevelName == LevelNameBase + 3){
            SceneManager.LoadScene(LevelNameBase + "4");
        }else if (LevelName == LevelNameBase + 4)
        {
            SceneManager.LoadScene(LevelNameBase + "5");
        }else if (LevelName == LevelNameBase + 5)
        {
            SceneManager.LoadScene(LevelNameBase + "5");
        }

        //}
    }

    // We can added different behaviors in different level.
    //void OnLevelWasLoaded()
    //{

    //}

	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(transform.gameObject);
        //NextLevelToGo = CurrentLevel + 1;
        //DebugValue = NextLevelToGo;

        //Debug.Log("start ----------------" + NextLevelToGo.ToString() + "    " + DebugValue.ToString());

	}
	
	// Update is called once per frame
	void Update () {

    }

    
}
