using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
	private AudioSource audioSource;
	// Use this for initialization
	void Start ()
    {
		audioSource = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			audioSource.Play();
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            collision.transform.position = player.GetSpawnPoint();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene(this.gameObject.scene.name);
        }
    }
}
