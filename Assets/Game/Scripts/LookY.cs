using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {
    private float _sensitivity = 1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float _mouseY = Input.GetAxis("Mouse Y");

        Vector3 newRot = transform.localEulerAngles;
        newRot.x -= _mouseY * _sensitivity;
        transform.localEulerAngles = newRot;
    }
}
