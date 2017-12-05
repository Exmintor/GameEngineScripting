using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuPanel;

    [SerializeField]
    private FirstPersonController character;

    private bool IsVisible
    {
        get
        {
            return inventoryMenuPanel.activeSelf;
        }
    }

    public List<InventoryObject> InventoryObjects { get; private set; }

    private void Awake()
    {
        InventoryObjects = new List<InventoryObject>();
    }
    // Use this for initialization
    void Start ()
    {
        HideMenu();
	}

    private void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if(Input.GetButtonDown("MenuButton"))
        {
            if(IsVisible)
            {
                HideMenu();
                character.enabled = true;
            }
            else
            {
                ShowMenu();
                character.enabled = false;
            }
        }
    }

    private void HideMenu()
    {
        inventoryMenuPanel.SetActive(false);
        UpdateCursor();
    }

    private void ShowMenu()
    {
        inventoryMenuPanel.SetActive(true);
        UpdateCursor();
    }

    private void UpdateCursor()
    {
        if(IsVisible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
