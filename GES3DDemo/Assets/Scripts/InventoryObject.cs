using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string nameText;

    [SerializeField]
    private string descriptionText;

	private InventoryMenu playerInventory;

    private MeshRenderer meshRenderer;
    private Collider thisCollider;

    private AudioSource audioSource;
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
    public string DescriptionText
    {
        get
        {
            return descriptionText;
        }
        private set
        {
            descriptionText = value;
        }
    }
	// Use this for initialization
	void Start ()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        thisCollider = GetComponent<Collider>();
        playerInventory = FindObjectOfType<InventoryMenu>();

        audioSource = GetComponent<AudioSource>();
	}

    public void Interact()
    {
        if(audioSource != null)
        {
            audioSource.Play();
        }
        meshRenderer.enabled = false;
        thisCollider.enabled = false;
        playerInventory.InventoryObjects.Add(this);
    }
}
