using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObject : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Transform teleportLocation;

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private string nameText;
	public string NameText 
	{ 
		get
		{
			return nameText;
		}
		set
		{
			nameText = value;
		}
	}

	public void Interact()
	{
		player.transform.position = new Vector3(teleportLocation.position.x, teleportLocation.position.y, teleportLocation.position.z);
	}
}
