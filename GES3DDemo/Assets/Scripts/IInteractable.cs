using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string NameText { get; }
    void Interact();
}
