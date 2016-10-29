using UnityEngine;
using System.Collections;

// Created by Eadmond, 10.26.2016
// This script is used to play collect and hurt effect.

// This script is accessed by PlayerMove script.

public class PlayerAudioController : MonoBehaviour {

    private AudioSource MyAudioSource;

    public AudioClip Collect1;
    public AudioClip Collect2;
    public AudioClip Collect3;
    public AudioClip Collect4;
    public AudioClip Collect5;
    public AudioClip Collect6;
    public AudioClip Collect7;

    public AudioClip Hurt;

    private string CollectNameBase = "Collect";

    public void OnCollect(int index)
    {
        if (index < 1)
            return;

        if(index == 1)
        {
            MyAudioSource.clip = Collect2;
        }else if(index == 2)
        {
            MyAudioSource.clip = Collect3;
        }
        else if (index == 3)
        {
            MyAudioSource.clip = Collect4;
        }
        else if (index == 4)
        {
            MyAudioSource.clip = Collect5;
        }
        else if (index == 5)
        {
            MyAudioSource.clip = Collect6;
        }
        else if (index == 6)
        {
            MyAudioSource.clip = Collect7;
        }
        else if (index >= 7)
        {
            MyAudioSource.clip = Collect7;
        }

        MyAudioSource.Play();
    }

    public void OnHurt()
    {
        MyAudioSource.clip = Hurt;

        MyAudioSource.Play();
    }


    // Use this for initialization
    void Start () {
        MyAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
