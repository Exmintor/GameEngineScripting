using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Text countText;
    [SerializeField]
    private Text winText;

    private Rigidbody rb;
    private int count;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >=12)
        {
            winText.text = "You Win!";
        }
    }
}
