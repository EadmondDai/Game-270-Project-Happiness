using UnityEngine;
using System.Collections;

public class Communicate : MonoBehaviour {
    //Behaviour halo;
    Light halo;
    public float fadeSpeed;
    public float pulseRadius;
    bool fading;
    private float startingRange;
    private bool growing;
   // bool faded;
    public bool Fading
    {
        get { return fading; }
        set { fading = value; }
    }
	void Start () {
        halo = GetComponent<Light>();
        startingRange = halo.range;
        growing = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (fading)
            HaloFade();
        else    
            Pulse();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
            fading = true;
    }
   
    void HaloFade()
    {
        halo.intensity -= fadeSpeed * Time.deltaTime;
        halo.range -= fadeSpeed * Time.deltaTime;
        if (halo.range <= 0)
            fading = false;
    }

    void Pulse()
    {
        if (growing)
        {
            //  Debug.Log(halo.range+ " "+ (startingRange-pulseDifference));
            //   
            halo.range += pulseRadius * Time.deltaTime;
            if (halo.range > startingRange + pulseRadius)
                growing = false;
        }
        else
        { 
            halo.range -= pulseRadius * Time.deltaTime;
            if (halo.range < startingRange - pulseRadius)
                growing = true;
        }
    }
}
