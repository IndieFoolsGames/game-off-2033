using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class KeyUiControler : MonoBehaviour
{
    public Transform keyContainer;

    public event UnityAction<GameObject> onKeyChanged;

    private Dictionary<KeyTypeCode,GameObject> keys = new Dictionary<KeyTypeCode,GameObject>();

    private void Start()
    {
        InitilizeKeys();
    }


    public void SetKey(KeyTypeCode keyTypeCode)
    {
        GameObject keyObject = keys[keyTypeCode];
        //Implent Set in Ui manager key keyTpe.gameobject as curnet active ui 
        OnKeyChanged(keyObject);
    }

    private void OnKeyChanged(GameObject keyObject)
    {
        if (onKeyChanged != null)
            onKeyChanged(keyObject);
    }

    private void InitilizeKeys() 
    {
        for (int i = 0; i < keyContainer.childCount; i++)
        {
            KeyTypeInfo key = keyContainer.GetChild(i).GetComponent<KeyTypeInfo>();

            if(key != null)
            {
                keys.Add(key.keyType,key.gameObject);
            }
        }
    }
}
