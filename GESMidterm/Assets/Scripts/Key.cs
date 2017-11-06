using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public static int keyCount = 0;

    private Text textField;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private AudioSource audioSource;
    private void Start()
    {
        textField = GameObject.Find("KeyCountText").GetComponent<Text>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        audioSource.Play();
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        //Destroy(this.gameObject);
        keyCount++;
        UpdateText();
    }

    private void UpdateText()
    {
        textField.text = "x " + keyCount + "/3";
    }
}
