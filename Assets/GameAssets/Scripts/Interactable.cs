using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //message displayed to player when looking at an interactable 
    public string promptMessage;

    //This funcion will be called from our player

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //we won't have any code written in this function
        //this is tempelate function to be overriden by our subclasses
    }

}
