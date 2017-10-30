using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            collision.gameObject.transform.position = player.GetSpawnPoint();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene(this.gameObject.scene.name);
        }
    }
}
