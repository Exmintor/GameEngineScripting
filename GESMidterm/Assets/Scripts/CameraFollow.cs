using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //This script goes onto a Camera which is suposed to follow the player
    [Tooltip("Object that the Camera follows")]
    [SerializeField]
    private GameObject player;

    private Vector3 offset;
	// Use this for initialization
	void Start ()
    {
        //Initial offset of camera relative to the player
        offset = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Reset the camera transform to floow its initial offset relative to the player
        this.transform.position = player.transform.position + offset;
	}
}
