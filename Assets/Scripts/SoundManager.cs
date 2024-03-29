﻿using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {


    // public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    // public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
   // public AudioClip ;
   // public AudioClip ;
    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
   // public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
   // public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
    private float semitoneConstant = 1.05964f;
    public int pitchMultiplier;

    public int pianoPitchMultiplier;
    public int padPitchMultiplier;
    //    public AudioSource piano;
    //    public AudioSource pad;
    public AudioSource[] audioSources;
    public Collector collector;
    private bool playing;
    //public AudioSource pad;
    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
        playing = false;
       // Debug.Log(piano.pitch);
        
    }

    void Update()
    {
        playing = checkIfPlaying();
       // playing = pad.isPlaying && piano.isPlaying;
        if(!playing)
            PlaySingle();
    }


    //Used to play single sound clips.
    public void PlaySingle()
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        //   efxSource.clip = clip;

        //Play the clip.
        //piano.PlayOneShot(piano.clip);
  //      pad.pitch = Mathf.Pow(semitoneConstant , padPitchMultiplier);
//        piano.pitch = Mathf.Pow(semitoneConstant, pianoPitchMultiplier);
 //       if(piano)piano.Play();
 //       if(pad)pad.Play();

        foreach (AudioSource aso in audioSources)
        
            aso.Play();
        


    }
    bool checkIfPlaying()
    {

        foreach (AudioSource aso in audioSources)
            if (aso.isPlaying) return true;
        return false;
    }
/*
    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips)
    {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        efxSource.clip = clips[randomIndex];

        //Play the clip.
        efxSource.Play();
    }
    */
}
