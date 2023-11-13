using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractReceiver : MonoBehaviour
{
    public KeyCode triggerKey;
    public bool OneInteraction;
    public string mesage;
   
    public UnityEvent onInteract;
    private bool interact = true;

    public void Interact()
    {
        onInteract.Invoke();
    }

    public void MyInput(KeyCode keyCode)
    {
        if (Input.GetKeyUp(triggerKey))
        {
            Debug.Log(mesage);
            Interact();
            ManageInteraction();
        }
    }

    void ManageInteraction()
    {
        if(OneInteraction)
        {
            interact = false;
        }       
    }

    public string GetMesage()
    {
        return mesage;
    }

    public bool CanInteract()
    {
        return interact;
    }
}

