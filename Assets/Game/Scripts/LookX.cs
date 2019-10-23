using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour {
    private float _sensitivity = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float _mouseX = Input.GetAxis("Mouse X");

        Vector3 newRot = transform.localEulerAngles;
        newRot.y += _mouseX * _sensitivity;
        transform.localEulerAngles = newRot;
	}
}
