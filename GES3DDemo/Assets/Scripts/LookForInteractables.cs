using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script is attached to a Player
// It finds Interactable objects and lets the player interact with them
public class LookForInteractables : MonoBehaviour
{
    [Tooltip("How far ahead does the player look")]
    [SerializeField]
    float reach = 5.0f;

    [Tooltip("The Main Camera used by the Player object")]
    [SerializeField]
    Camera playerCamera;

    [Tooltip("Text field of the UI that holds the name of an Interactbale object")]
    [SerializeField]
    Text nameText;

    // Update is called once per frame
    void Update()
    {
        // Default interactble text
        nameText.text = "";

        LookForObject();
    }

    /// <summary>
    /// Casts a Ray in a straight line ahead of the player from the midpoint of the screen
    /// </summary>
    private void LookForObject()
    {
        // Middle of the screen
        //int x = Screen.width / 2;
        //int y = Screen.height / 2;

        // Ray Starting point
        //Ray ray = playerCamera.ScreenPointToRay(new Vector3(x, y, 0));
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * reach, Color.magenta);
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hitObject;
        // If the ray collides with an object within reach...
        if (Physics.Raycast(ray, out hitObject, reach))
        {
            // ...Check to see if it can be interacted with, and whether the player is trying to interact with it
            CheckForInteractionInput(hitObject);
        }
    }

    /// <summary>
    /// Checks to see if an Object hit by a Ray is Interactable.
    /// If it is, check for Player input
    /// </summary>
    /// <param name="hitObject">The object hit by the Ray</param>
    private void CheckForInteractionInput(RaycastHit hitObject)
    {
        //IInteractable interactableObject = hitObject.collider.gameObject.GetComponent<IInteractable>();
        IInteractable interactableObject = hitObject.transform.gameObject.GetComponent<IInteractable>();
        // Check to see if the object is Interactable
        if (interactableObject != null)
        {
            // Updates the UI text field with the name of the object
            ChangeUINameText(interactableObject);

            if (Input.GetButtonDown("Interact"))
            {
                interactableObject.Interact();
            }
        }
    }

    private void ChangeUINameText(IInteractable interactableObject)
    {
        nameText.text = interactableObject.NameText;
    }
}
