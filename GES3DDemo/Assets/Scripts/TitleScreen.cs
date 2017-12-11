using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private AudioSource clickSound;

    private void Start()
    {
        clickSound = GetComponent<AudioSource>();
    }
    public void StartButtonClicked()
    {
        PlayClickSound();
        SceneManager.LoadScene("TestScene");
    }

    public void CreditsButtonClicked()
    {
        PlayClickSound();
        SceneManager.LoadScene("CreditScene");
    }

    private void PlayClickSound()
    {
        if(clickSound != null)
        {
            clickSound.Play();
        }
    }
}
