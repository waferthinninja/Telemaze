using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapped : MonoBehaviour
{

    private PlayerController Player;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

	public void OnTriggerEnter(Collider col)
    {
        Player.Trapped();
    }
}
