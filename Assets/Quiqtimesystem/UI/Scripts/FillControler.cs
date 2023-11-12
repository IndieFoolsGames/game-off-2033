
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class FillControler : MonoBehaviour
{
    public Image fillImage;
    public float fillSped = 0.2f;

    private float targetFillState = 0;

    // Update is called once per frame
    void Update()
    {
        if (fillImage != null && targetFillState == 0 || targetFillState == fillImage.fillAmount)
            return;

        float fill = Math.Clamp(fillSped * Time.deltaTime, 0, targetFillState);
        fillImage.fillAmount = fill;
    }

    public void ResetFill()
    {
        fillImage.fillAmount = 0;
        targetFillState = 0;
    }

    public void SetTargetFill(float targetFill)
    {
        targetFillState = Math.Clamp(targetFillState, 0, 100) / 100;
    }
}
