using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTreasure : MonoBehaviour, IInteractable
{

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
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		SceneManager.LoadScene("WinScene");
	}
}
