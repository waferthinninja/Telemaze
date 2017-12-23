using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            var player = col.gameObject.GetComponent<PlayerController>();
            if (player.TeleportTimeout <= 0f)
            {
                player.StartTimeout();
                col.transform.position = target.position;
            }
        }

    }
}
