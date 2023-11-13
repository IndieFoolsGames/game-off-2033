using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionPointer : MonoBehaviour
{
    //Settings
    public float rayDist;
    public LayerMask interaction;
    public Color rayGizmoColor;

    private InteractReceiver curentReceiver;
    private Ray ray;
   
    public UnityAction<KeyCode> OnInput;
    public PlayerMesage playerMesage;

    // Update is called once per frame
    void Update()
    {      
        RaycastHit hit = Ray();

        if (hit.collider != null)
        {
            if (curentReceiver == null)
            {
                Debug.Log("Has hit");
                Transform transform = hit.collider.transform;
                FindReceiver(transform.root);
                OnInput += curentReceiver.MyInput;

                playerMesage.Mesage(curentReceiver.GetMesage());
            }
        }
        else
        {         
            if (curentReceiver)
            {               
                OnInput -= curentReceiver.MyInput;
                playerMesage.Mesage(false);
                curentReceiver = null;
            }
            return;
        }

        if (curentReceiver.CanInteract())
        {
            SendInput();
            return;
        }   
        else
        {
            playerMesage.Mesage(false);
        }
    }

   
    void SendInput()
    {                 
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {                         
            if (Input.GetKeyUp(vKey))
            {                  
                OnInput(vKey);                                 
            }
        }       
    }

    void FindReceiver(Transform start)
    {
        curentReceiver = start.GetComponent<InteractReceiver>();
        if (curentReceiver != null)
            return;

        float childCount = start.childCount;
        Transform curentChild;       

      
        for (int i = 0; i < childCount; i++)
        {
            curentChild = start.GetChild(i);
            curentReceiver = curentChild.GetComponent<InteractReceiver>();
            if (curentReceiver != null)
                return;

            if (curentChild.childCount > 0)
            {
                FindReceiver(curentChild);
            }       
            
            if(curentReceiver != null)
               return;
        }                
    }
    
    RaycastHit Ray()
    {
        RaycastHit hit = new RaycastHit();
        bool rayResult = Physics.Raycast(transform.position, transform.forward, out hit, rayDist, interaction);
        return hit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = rayGizmoColor;
        Gizmos.DrawRay(transform.position,transform.forward * rayDist);
    }
}
