using UnityEngine;
using System.Collections;

// Created by Eadmond, 10.26.2016
// This script is used to play bgm and transcene music.

// This script access the MySceneManager script.
// This script is accessed by the PlayerMove script.

public class MySoundManager : MonoBehaviour {

    // Related to looping throung deffirent songs.
    public GameObject SceneManager;

    private AudioSource MyAudioSource;

    public AudioClip BGMLoop1;
    public AudioClip BGMLoop2;
    public AudioClip BGMLoop3;
    public AudioClip BGMLoop4;
    public AudioClip BGMLoop5;
    public AudioClip BGMLoop6;
    public AudioClip BGMLoop7;

    private AudioClip[] AllTrack;

    private int CurBMGIndex = 1;

    private int CurLevel;

    // Use this for initialization
    void Start () {
        // Do something with the background music.
        CurLevel = SceneManager.GetComponent<MySceneManager>().CurrentLevel;

        if (CurLevel > 2)
            return;

        MyAudioSource = GetComponent<AudioSource>();
        //AllTrack.Add(BGMLoop1);
        //AllTrack.Add(BGMLoop2);
        //AllTrack.Add(BGMLoop3);
        //AllTrack.Add(BGMLoop4);
        //AllTrack.Add(BGMLoop5);
        //AllTrack.Add(BGMLoop6);
        //AllTrack.Add(BGMLoop7);
        AllTrack = new AudioClip[] { BGMLoop1, BGMLoop2, BGMLoop3, BGMLoop4, BGMLoop5, BGMLoop6, BGMLoop7 };

        MyAudioSource.clip = AllTrack[0];
        MyAudioSource.loop = true;
        MyAudioSource.Play();
    }

    // Index is one bigger than actually resqued friend.
    public void OnPickUp(int Index)
    { 
        if (Index < 0 || Index >= 7 || CurLevel > 2)
            return;

        MyAudioSource.clip = (AudioClip)AllTrack[Index];
        MyAudioSource.Play();


    }

    // Update is called once per frame
    void Update () {
	
	}
}
