using UnityEngine;
using System.Collections;
// Created by Eadmond 10.20.2016
// This script will determine how fast the gameobject rotate and orbit.


public class Orbit2D : MonoBehaviour {

    public Transform OrbitTrans;

    public float RotateSpeed = 1;
    public float OrbitDegree = 1;

    // The Size control how big the gameobject is and the mass of the gameobject.
    public float Size = 1;

    public bool IsOrbiting = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (OrbitTrans == null)
            return;

        float timeDelta = Time.deltaTime;

        // Make itself rotate and orbit.

        // Rotate randomly.
        Vector3 rotateAix = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1) );

        transform.Rotate(rotateAix, RotateSpeed * timeDelta / Size);

        transform.RotateAround(OrbitTrans.position, Vector3.forward, OrbitDegree / Size);	

	}

    public void SetOrbitTrans(Transform trans)
    {
        OrbitTrans = trans;

        IsOrbiting = true;
    }

    public bool IsItOrbiting()
    {
        return IsOrbiting;
    }
}
