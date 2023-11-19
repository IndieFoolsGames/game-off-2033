using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class KeyManager : MonoBehaviour
{
    public KeyDataManager keyDataManager;

    private KeyData1 curentKey;

    

    public event UnityAction<KeyData1> onKeyHasChanged;

    public void SetKey(KeyTypeCode keyTypeCode)
    {
        if (keyDataManager.Data.TryGetValue(keyTypeCode, out KeyData1 keyData))
        {
            OnKeyHasChanged(keyData);
        }
    }

    private void OnKeyHasChanged(KeyData1 key)
    {
        if (onKeyHasChanged != null)
        {
            onKeyHasChanged.Invoke(key);
        }
    }
}
