using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Transform StartPoint;

    private int Score = 0;
    public int WinScore = 7;
    
    public RectTransform TitlePanel;
    public RectTransform VictoryPanel;
    public RectTransform TrappedPanel;

    private Action OnReset;
    public void RegisterOnReset(Action action) { OnReset += action; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

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

            if (inputDir != new Vector3())
            {

                TitlePanel.gameObject.SetActive(false);
            }

            Animator.SetBool("IsWalking", inputDir != Vector3.zero);

            transform.LookAt(transform.position + inputDir, transform.up);

            transform.Translate(inputDir * Time.deltaTime * Speed, Space.World);

            TeleportTimeout -= Time.deltaTime;
        }

        
	}

    private void ResetPanels()
    {
        TitlePanel.gameObject.SetActive(true);
        VictoryPanel.gameObject.SetActive(false);
        TrappedPanel.gameObject.SetActive(false);
    }

    public void AddScore(int points)
    {
        Score += points;
        if (Score >= WinScore)
        {
            Victory();
        }
    }

    private void Victory()
    {
        VictoryPanel.gameObject.SetActive(true);
    }

    public void Trapped()
    {

        VictoryPanel.gameObject.SetActive(false);
        TrappedPanel.gameObject.SetActive(true);

    }

    public void Reset()
    {
        Score = 0;
        transform.position = StartPoint.position;
        ResetPanels();

        if (OnReset != null)
        {
            OnReset();
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
