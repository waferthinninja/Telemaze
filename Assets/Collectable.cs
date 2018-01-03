using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    private MeshRenderer Renderer;
    private Collider Collider;
    public AudioClip PickupSound;
    private AudioSource AudioSource;
    private PlayerController Player;

    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
        Collider = GetComponent<Collider>();
        AudioSource = GetComponent<AudioSource>();
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        Player.RegisterOnReset(OnReset);
    }

    public void OnTriggerEnter(Collider col)
    {
        Renderer.enabled = false;
        Collider.enabled = false;
        AudioSource.PlayOneShot(PickupSound);
        Player.AddScore(1);
    }

    public void OnReset()
    {
        Renderer.enabled = true;
        Collider.enabled = true;
    }

}
