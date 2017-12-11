using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItem : MonoBehaviour
{

	private InventoryMenu inventoryMenu;

	public InventoryObject ObjectRepresented { get; set;}

	void Start()
	{
		inventoryMenu = FindObjectOfType<InventoryMenu>();
	}
    public void InventoryObjectWasClicked()
    {
		inventoryMenu.UpdateDescriptionAreaText(ObjectRepresented.DescriptionText);
    }
}
