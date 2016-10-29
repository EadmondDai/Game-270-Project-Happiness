using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

// Created by Eadmond, 10.24.2016
// This script is used to control all the scene management and restart the game.
// This script is able to change different requirement for each level.

// This script is accessed by CameraMove script.
// This script is accessed by PlayerMove script


public class MySceneManager : MonoBehaviour {

    // Something wrong with these variables. 
    // Started from this one.
    public int CurrentLevel = 0;
    [SerializeField]
    Animator an;
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
            StartCoroutine(ExitAnimation(LevelNameBase + "2"));
           // SceneManager.LoadScene(LevelNameBase + "2");
        }else if(LevelName == LevelNameBase + 2)
        {
            StartCoroutine(ExitAnimation(LevelNameBase + "3"));
            //SceneManager.LoadScene(LevelNameBase + "3");
        }else if (LevelName == LevelNameBase + 3){
            StartCoroutine(ExitAnimation(LevelNameBase + "4"));
            //SceneManager.LoadScene(LevelNameBase + "4");
        }else if (LevelName == LevelNameBase + 4)
        {
            StartCoroutine(ExitAnimation(LevelNameBase + "5"));
            //SceneManager.LoadScene(LevelNameBase + "5");
        }else if (LevelName == LevelNameBase + 5)
        {
            StartCoroutine(ExitAnimation(LevelNameBase + "5"));
            //SceneManager.LoadScene(LevelNameBase + "5");
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
    //END LEVEL
    void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pressed");

            StartCoroutine(ExitAnimation("Level 2"));
            Debug.Log("after button pressed");
            
        }
        
        
    }

    void Awake()
    {
        an = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        an.speed = 0;
    }
   
    IEnumerator ExitAnimation(string s)
    {
        
        an.Play("LevelOutro", -1, 0f);
        
        an.speed = 1;
        yield return new WaitForSeconds(2.98f);
        SceneManager.LoadScene(s);
       
    }

}
