using UnityEngine;
using System.Collections;

// Created by Eadmond 10.20.2016
// This script is responsiable for control the player's moving and play particle ring when collect a friend.

public class PlayerMove : MonoBehaviour {

    public float Speed = 1;

    private ParticleSystem Ring;

    bool test = false;

	// Use this for initialization
	void Start () {
        Ring = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        float deltaTime = Time.deltaTime;

        {
            float moveInput = Input.GetAxis("Horizontal");
            Vector3 moveValue = new Vector3(moveInput, 0, 0);
            transform.Translate(moveValue * Speed * deltaTime, Space.World);
        }

        {
            float moveInput = Input.GetAxis("Vertical");
            Vector3 moveValue = new Vector3(0, moveInput, 0);
            transform.Translate(moveValue * Speed * deltaTime, Space.World);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("You hitted something.");
        if(col.tag == "Friend")
        {
            Ring.Play();
        }

    }


}
