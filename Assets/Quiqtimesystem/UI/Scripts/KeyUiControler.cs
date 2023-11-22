using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class KeyUiControler : MonoBehaviour
{
    public UIManger uImanger;
    public KeyManager keyManager;

    // Start is called before the first frame update
    void Start()
    {
        if (keyManager != null)
            keyManager.onKeyHasChanged += UpdateKeyUI;
    }

    private void ChangeKeyUi(UIElement uIElement)
    {
        uImanger.ChanngeUI(uIElement);
    }

    private void UpdateKeyUI(KeyData1 keyData1)
    {
        UIElement uIElement = keyData1.Ui;
        ChangeKeyUi(uIElement);
    }
}
