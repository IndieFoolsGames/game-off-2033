using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class KeyTypeManager : MonoBehaviour
{
    public event UnityAction<GameObject> onKeyChanged;
    private Dictionary<KeyTypeCode,GameObject> keys = new Dictionary<KeyTypeCode,GameObject>();

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
}
