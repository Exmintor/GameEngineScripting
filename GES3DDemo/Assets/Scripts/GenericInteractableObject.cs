using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteractableObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interaction Successful");
    }
}
