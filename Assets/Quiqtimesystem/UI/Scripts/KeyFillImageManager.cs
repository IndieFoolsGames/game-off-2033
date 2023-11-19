using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyFillImageManager : MonoBehaviour
{
    public KeyManager KeyManager;
    public FillControler fillControler;
    // Start is called before the first frame update
    void Start()
    {
        if (KeyManager != null)
            KeyManager.onKeyHasChanged += UpdateFillImage;
    }

    private void UpdateFillImage(KeyData1 keyData1)
    {
        Image image = keyData1.fillImage;
        SetFillImage(image);
    }

    public void SetFillImage(Image image)
    {
        if(fillControler != null)
            fillControler.fillImage = image;
    }
}
