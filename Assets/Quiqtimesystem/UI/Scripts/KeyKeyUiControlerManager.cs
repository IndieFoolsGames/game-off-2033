using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyKeyUiControlerManager : MonoBehaviour
{
    public KeyManager typeSeter;

    private KeyCodeUiControlerBase keyCodeUiControlerBase;

    

    private void Start()
    {
        if(typeSeter != null)
        {
            typeSeter.onKeyHasChanged += UpdateControler;
        }
    }

    public void SetKey(KeyCode keyCode)
    {
        if (keyCodeUiControlerBase != null)
            keyCodeUiControlerBase.SetKey(keyCode);
    }

    private void UpdateControler(KeyData1 keyData1)
    {
        keyCodeUiControlerBase = keyData1.uiControler;
    }
}
