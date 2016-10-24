using UnityEngine;
using System.Collections;

public class Collector: MonoBehaviour {
    public int partsToCollect;
    public ParticleSystem fog;
    private float densityStep;
    int collectedParts;
    float maxDensity;
    // Use this for initialization
	void Start () {
        collectedParts = 0;
        maxDensity = fog.startSize;
        densityStep = maxDensity / partsToCollect;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider col)
    {
        if( col.tag == "Friend")
        {
            partsToCollect--;
            changeFogDensity(-densityStep); 
        }
        //todo
        if (col.tag == "Enemy") {
            changeFogDensity(densityStep);
        }
    }

    void changeFogDensity(float changeBy)
    {
        if (fog.startSize + changeBy < 0)
            fog.startSize = 0;
        else if (fog.startSize + changeBy > maxDensity)
            fog.startSize = maxDensity;
        else
            fog.startSize += changeBy;
    }
}
