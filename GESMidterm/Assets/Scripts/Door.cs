using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;
    [SerializeField]
    private int keysNeeded = 3;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Key.keyCount == keysNeeded)
        {
            if(Input.GetButtonDown("OneWay"))
            {
                Key.keyCount = 0;
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
