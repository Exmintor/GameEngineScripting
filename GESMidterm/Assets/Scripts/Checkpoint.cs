using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 playerSpawnPoint;

    private bool isActive = false;

    [SerializeField]
    Sprite activatedSprite;
    [SerializeField]
    Sprite deactivatedSprite;

    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start ()
    {
        playerSpawnPoint = this.transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        spriteRenderer.sprite = activatedSprite;
        isActive = true;
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        player.ChangeSpawnPoint(this);
    }

    public void DeactivateCheckpoint()
    {
        spriteRenderer.sprite = deactivatedSprite;
        isActive = false;
    }
}
