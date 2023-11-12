using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuicktimeUiControler : MonoBehaviour
{
    public Key key;
    public KeyUiControler uiControler;

    public void SetKey(KeyTypeCode keyType, string action, KeyCode keyCode)
    {
        uiControler.SetKey(keyType);
        key.KeyControler.SetKeyCode(keyCode);
        key.KeyControler.SetState(action);
    }

    public void ChangeKeyCode(KeyCode keyCode)
    {
        key.KeyControler.SetKeyCode(keyCode);
    }

    public void ChangeAction(string action)
    {
        key.KeyControler.SetState(action);
    }

    public void Fill()
    {

    }
}
