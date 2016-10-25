using UnityEngine;
using System.Collections;

// Created by Eadmond 10.20.2016
// This script is responsiable for control the player's moving and play particle ring when collect a friend.

// This script access Orbit2D script;
// This script access PlayerHaloController script;

public class PlayerMove : MonoBehaviour {

    public float Speed = 1;

    private ParticleSystem Ring;

    private PlayerHaloController HaloController;

    bool test = false;

	// Use this for initialization
	void Start () {
        Ring = GetComponent<ParticleSystem>();
        HaloController = GetComponent<PlayerHaloController>();
    }
	
	// Update is called once per frame
	void Update () {
        float deltaTime = Time.deltaTime;
        Vector3 moveValue;
        moveValue.z = 0;
        {
            float moveInput = Input.GetAxis("Horizontal");
            moveValue.x = moveInput;
        }

        {
            float moveInput = Input.GetAxis("Vertical");
            moveValue.y = moveInput;   
        }
        transform.Translate(moveValue.normalized * Speed * deltaTime, Space.World);

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Friend")
        {
            Orbit2D orbit2DScript = col.GetComponent<Orbit2D>();

            if(!orbit2DScript.IsItOrbiting())
            {
                Ring.Play();
                orbit2DScript.SetOrbitTrans(transform);
                HaloController.AddLight();
            }
        }

        if(col.tag == "Enemy")
        {
            HaloController.MinusLight();
        }

    }


}
