using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed = 2f;

    private float TeleportTimeout = 0f;

    public float TimeoutLength = 2f;
    public float TeleportSpeed = 20f;

    private Vector3 TargetPosition;
    private bool isTeleporting = false;
    
    public ParticleSystem EndTeleportEffect;
    public Renderer Renderer;

    public float teleportDuration = 0.25f;
    private float teleportTimer = 0f;

    public Animator Animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isTeleporting)
        {
            if (teleportTimer <= 0f)

            { 
                transform.position = TargetPosition;
                EndTeleport();
            }
            else
            {
                teleportTimer -= Time.deltaTime;
            }
        }
        else
        {
            Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            Animator.SetBool("IsWalking", inputDir != Vector3.zero);

            transform.LookAt(transform.position + inputDir, transform.up);

            transform.Translate(inputDir * Time.deltaTime * Speed, Space.World);

            TeleportTimeout -= Time.deltaTime;
        }

        
	}

    public bool TryTeleport(Vector3 target)
    {
        if (TeleportTimeout <= 0f)
        {
            StartTeleport(target);
            return true;
        }
        return false;
    }

    private void StartTeleport(Vector3 target)
    {
        TargetPosition = target;
        isTeleporting = true;
        TeleportTimeout = TimeoutLength;
        Renderer.enabled = false;
        teleportTimer = teleportDuration;
    }

    private void EndTeleport()
    {
        isTeleporting = false;
        EndTeleportEffect.Play();
        Renderer.enabled = true;
    }
}
