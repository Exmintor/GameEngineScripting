using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isOpen = false;
    private Animator animator;
	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Interact()
    {
        ReverseIsOpen();
        animator.SetBool("isOpen", isOpen);
    }

    public void ReverseIsOpen()
    {
        switch(isOpen)
        {
            case true:
                isOpen = false;
                break;
            case false:
                isOpen = true;
                break;
        }
    }
}
