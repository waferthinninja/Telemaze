using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed = 2f;

    public float TeleportTimeout = 0f;

    public float TimeoutLength = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.Translate(inputDir * Time.deltaTime * Speed);

        TeleportTimeout -= Time.deltaTime;
	}

    public void StartTimeout()
    {
        TeleportTimeout = TimeoutLength;
    }
}
