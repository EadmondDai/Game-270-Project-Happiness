using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour {

    public float Speed = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float deltaTime = Time.deltaTime;

        //if(Input.GetKeyDown("Horizontal"))
        {
            float moveInput = Input.GetAxis("Horizontal");
            Debug.Log(moveInput);
            Vector3 moveValue = new Vector3(moveInput, 0, 0);
            transform.Translate(moveValue * Speed * deltaTime, Space.World);
        }

        //if(Input.GetKeyDown("Vertical"))
        {
            float moveInput = Input.GetAxis("Vertical");
            Vector3 moveValue = new Vector3(0, moveInput, 0);
            transform.Translate(moveValue * Speed * deltaTime, Space.World);
        }
        
        	
	}
}
