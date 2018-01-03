using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationEvent : MonoBehaviour {

    public AudioClip[] FootstepSounds;

    private AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void Footstep()
    {
        int n = Random.Range(0, FootstepSounds.Length - 1);

        var clip = FootstepSounds[n];

        AudioSource.PlayOneShot(clip);
    }
}
