using UnityEngine;
using System.Collections;

// Created by Eadmond 10.20.2016
// This script is responsiable for control the player's moving and play particle ring when collect a friend.
// This script keep record of number of cubes collected.

// This script access Orbit2D script;
// This script access PlayerHaloController script;
// This script access PlayerAudioController script;
// This script access MySoundManager script.

public class PlayerMove : MonoBehaviour {

    public float Speed = 1;

    private ParticleSystem Ring;

    private PlayerAudioController PlayerAudioScript;

    private PlayerHaloController HaloController;

    public GameObject MySceManaObj;

    public int FriendResued = 0;

    public int FriendNeedForThisLevel = 6;

    // Related to speed

    public float ResqueAddSpeed = 0.02f;

    public float EnemyMinusSpeed = 0.04f;

    // Related to level 1 and level 2 music.

    public GameObject MySoundManagerObj;

    private MySoundManager MySoundManagerScript;

	// Use this for initialization
	void Start () {
        Ring = GetComponent<ParticleSystem>();
        HaloController = GetComponent<PlayerHaloController>();
        PlayerAudioScript = GetComponent<PlayerAudioController>();
        MySoundManagerScript = MySoundManagerObj.GetComponent<MySoundManager>();
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

                FriendResued++;

                Speed += ResqueAddSpeed;

                PlayerAudioScript.OnCollect(FriendResued);

                MySoundManagerScript.OnPickUp(FriendResued);
            }
        }

        if(col.tag == "Enemy")
        {
            HaloController.MinusLight();

            Speed -= EnemyMinusSpeed;

            PlayerAudioScript.OnHurt();
        }
    }


}
