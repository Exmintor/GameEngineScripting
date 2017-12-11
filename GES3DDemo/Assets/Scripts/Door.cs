using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string nameText;
	private string originalName;
    public string NameText
    {
        get
        {
            return nameText;
        }
        private set
        {
            nameText = value;
        }
    }

	[SerializeField]
	private InventoryMenu playerInventory;
	[SerializeField]
	private InventoryObject key;

    private bool isOpen = false;
    private Animator animator;

	private bool hasKey = false;
	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
		originalName = NameText;
	}
	
	// Update is called once per frame
	void Update ()
    {
		CheckForKey();
		UpdateDoorName ();
	}

	private void UpdateDoorName()
	{
		if (!hasKey) 
		{
			NameText = originalName + "\n (LOCKED)";
		}
		else
		{
			NameText = originalName + "\n (UNLOCKED)";
		}
	}
	private void CheckForKey()
	{
		if (playerInventory.InventoryObjects.Contains(key)) 
		{
			hasKey = true;
		}
	}
    public void Interact()
    {
		if (hasKey) 
		{
			ReverseIsOpen();
			animator.SetBool("isOpen", isOpen);
		}
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
