using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 playerSpawnPoint;

    private bool isActive = false;

    [SerializeField]
    float activatedScale;
    [SerializeField]
    float deactivatedScale;
    [SerializeField]
    Color activatedColor;
    [SerializeField]
    Color deactivatedColor;
    // Use this for initialization
    void Start ()
    {
        playerSpawnPoint = this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Vector3 GetSpawnPoint()
    {
        return playerSpawnPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isActive)
        {
            ActivateCheckpoint(collision);
        }
    }

    private void ActivateCheckpoint(Collider2D collision)
    {
        isActive = true;
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        player.ChangeSpawnPoint(this);
    }

    public void DeactivateCheckpoint()
    {
        isActive = false;
    }
}
