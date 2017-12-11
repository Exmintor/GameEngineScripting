using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuPanel;

    [SerializeField]
    private FirstPersonController character;

	[SerializeField]
	private Text descriptionAreaText;

	[SerializeField]
	private GameObject itemPrefab;
	[SerializeField]
	private Transform inventoryItemListPanel;

    private bool IsVisible
    {
        get
        {
            return inventoryMenuPanel.activeSelf;
        }
    }

    public List<InventoryObject> InventoryObjects { get; private set; }
	private List<GameObject> menuItems;

    private void Awake()
    {
        InventoryObjects = new List<InventoryObject>();
		menuItems = new List<GameObject>();
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

	public void UpdateDescriptionAreaText(string descriptionText)
	{
		descriptionAreaText.text = descriptionText;
	}

	private void UpdateMenuItems()
	{
		foreach (InventoryObject item in InventoryObjects) 
		{
			GameObject newMenuItem = Instantiate (itemPrefab, inventoryItemListPanel) as GameObject;
			newMenuItem.GetComponent<Toggle>().group = inventoryItemListPanel.GetComponent<ToggleGroup>();
			newMenuItem.GetComponentInChildren<Text>().text = item.NameText;
			newMenuItem.GetComponent<InventoryMenuItem>().ObjectRepresented = item;
			menuItems.Add(newMenuItem);
		}
	}

	private void DestroyInventoryObjects()
	{
		foreach(GameObject item in menuItems)
		{
			Destroy(item);
		}
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
		DestroyInventoryObjects();
        UpdateCursor();
    }

    private void ShowMenu()
    {
		UpdateMenuItems ();
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
