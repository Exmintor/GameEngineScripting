using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        horizontalInput = Input.GetAxis("Horizontal");
	}

    public float GetHorizontal()
    {
        return horizontalInput;
    }
    public bool IsPressed(string key)
    {
        if(Input.GetButton(key))
        {
            return true;
        }
        return false;
    }
    public bool IsPressedOnce(string key)
    {
        if (Input.GetButtonDown(key))
        {
            return true;
        }
        return false;
    }
}
