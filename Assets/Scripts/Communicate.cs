using UnityEngine;
using System.Collections;

public class Communicate : MonoBehaviour {
    //Behaviour halo;
    Light halo;
    public float fadeSpeed;
    bool fading;
   // bool faded;
    public bool Fading
    {
        get { return fading; }
        set { fading = value; }
    }
	void Start () {
        // halo = (Behaviour)GetComponent("Halo");
        halo = GetComponent<Light>();

    }
	
	// Update is called once per frame
	void Update () {
        if (fading)
            haloFade();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
            fading = true;
            // halo.enabled = false;
            //haloFade();
    }
   
    void haloFade()
    {
//        if (halo = GetComponent<Light>()) Debug.Log("niccce");
        halo.intensity -= fadeSpeed * Time.deltaTime;
        halo.range -= fadeSpeed * Time.deltaTime;
        if (halo.range <= 0)
            fading = false;
            //faded = true;
        
        //Debug.Log(halo.GetType().GetProperty("size"));//.SetValue(halo, false, null);
    }
}
