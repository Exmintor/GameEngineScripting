using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    static int coinCount = 0;

    private Text textField;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private AudioSource audioSource;
    private void Start()
    {
        textField = GameObject.Find("CoinCountText").GetComponent<Text>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
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
        coinCount++;
        UpdateText();
    }

    private void UpdateText()
    {
        textField.text = "Coins: " + coinCount;
    }
}
