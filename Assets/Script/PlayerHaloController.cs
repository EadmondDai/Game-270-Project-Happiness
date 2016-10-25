using UnityEngine;
using System.Collections;

// Created by Eadmond 10.24.2016
// This script is used to control the intensity of halo of the player

// This script is accessed by PlayerMove script;
// This script access the MySceneManager script;

public class PlayerHaloController : MonoBehaviour {

    public float AddHaloAmount = 0.3f;

    public float AddHaloRangeAmount = 0.3f;

    public Light HaloLight;

    public GameObject MySceneManaObj;

    // Add some light to the world.
    public void AddLight()
    {
        HaloLight.range += AddHaloAmount;
        HaloLight.intensity += AddHaloAmount;
    }

    public void MinusLight()
    {
        HaloLight.range -= AddHaloAmount;
        HaloLight.intensity -= AddHaloAmount;

        if (HaloLight.intensity <= 0)
        {
            MySceneManager MySceneManagerScript = MySceneManaObj.GetComponent<MySceneManager>();

            MySceneManagerScript.RestartLevel();
        }
           
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
