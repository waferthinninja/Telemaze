using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public Transform target;
    public ParticleSystem StartTeleportEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            var player = col.gameObject.GetComponent<PlayerController>();
            
            if (player.TryTeleport(target.position))
            {
                StartTeleportEffect.Play();
            }
                
        }

    }
}
