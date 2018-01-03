using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public Transform target;
    public ParticleSystem StartTeleportEffect;

    private AudioSource AudioSource;
    public AudioClip[] TeleportSounds;

	// Use this for initialization
	void Start () {
        AudioSource = GetComponent<AudioSource>();
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
                int n = Random.Range(0, TeleportSounds.Length - 1);
                var clip = TeleportSounds[n];
                AudioSource.PlayOneShot(clip);
            }
                
        }

    }
}
