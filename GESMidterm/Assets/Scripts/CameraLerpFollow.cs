using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerpFollow : MonoBehaviour {

    //This script goes onto a Camera which is suposed to follow the player
    //It has a smooth LERP instead of snapping to the location
    [Tooltip("Object that the Camera follows")]
    [SerializeField]
    private GameObject player;

    [Tooltip("Speed of the camera follow")]
    [SerializeField]
    private float lerpSpeed = 5;

    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        //Initial offset of camera relative to the player
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Reset the camera transform to floow its initial offset relative to the player
        Vector3 newPosition = player.transform.position + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, newPosition, lerpSpeed * Time.deltaTime);
    }
}
