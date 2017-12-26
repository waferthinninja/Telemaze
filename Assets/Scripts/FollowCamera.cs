using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public Transform Target;
    public float Speed;
    private Vector3 Offset;

	// Use this for initialization
	void Start () {
        Offset = transform.position - Target.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target = Target.transform.position + Offset;
        //Vector3 moveVector = (target - transform.position) * Speed * Time.deltaTime;
        //if (moveVector.magnitude >= (target - transform.position).magnitude)
        //{
            transform.position = target;
        //} 
        //else
        //{
        //    transform.Translate(moveVector);
        //}
	}
}
