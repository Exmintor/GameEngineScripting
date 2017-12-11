using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScreen : MonoBehaviour
{
    private AudioSource clickSound;

    private void Start()
    {
        clickSound = GetComponent<AudioSource>();
    }
    public void BackButtonClicked()
    {
        if(clickSound != null)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("TitleScene");
    }
}
