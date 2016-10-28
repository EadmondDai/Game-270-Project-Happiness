using UnityEngine;
using System.Collections;

// Created by Eadmond, 10.27.2016
// This script makes enmey and friend chase the player. When the gameobject is rendered.

public class ChasePlayer : MonoBehaviour {

    public GameObject PlayerObj;

    private bool Chaseing = false;

    private Renderer MyRenderer;

    public float ChaseSpeed = 1;

    void OnBecameVisible()
    {
        Chaseing = true;

    }

    void OnBeCameInvisible()
    {
        Chaseing = false;
    }

    // Use this for initialization
    void Start () {
        MyRenderer = GetComponent<MeshRenderer>();
	}

    // Update is called once per frame
    void Update() {
        float step = ChaseSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, PlayerObj.transform.position, ChaseSpeed);

	}
}
