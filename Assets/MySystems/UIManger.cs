using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManger : MonoBehaviour
{    
    public UIElement[] uIGroups;    
    private UIElement activeUiGroup;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OppenPanell(int nextIndexPanel)
    {       
        activeUiGroup = uIGroups[nextIndexPanel];

        if (activeUiGroup.GetActive())
            return;

        activeUiGroup.SetActive(true);
    }

    public void ChangePannell(int nextIndexPanel)
    {
        UIElement nextGroup = uIGroups[nextIndexPanel]; 
        
        if(activeUiGroup != null && nextGroup == activeUiGroup && activeUiGroup.GetActive())
            return;

        ChanngeUI(nextGroup);
    }

    public void ClosetPanel(int pannellIndex)
    {
        UIElement group = uIGroups[pannellIndex];

        if(!group.GetActive())
            return;

        group.SetActive(false);
    }

    public void CloseCurentPanel()
    {
        if (activeUiGroup != null)
            activeUiGroup?.SetActive(false);  
    }

    
    public bool IsPannellOppen(int pannellIndex)
    {
        UIElement nextGroup = uIGroups[pannellIndex];
        return nextGroup.GetActive();
    }   
        
    public bool IsActive()
    {
        if (activeUiGroup != null)
            return activeUiGroup.IsActive;
        
        return false;
    }

    public void ChanngeUI(UIElement uIGroup)
    {
        if(activeUiGroup != null)     
            activeUiGroup.SetActive(false);

        activeUiGroup = uIGroup;
        activeUiGroup.SetActive(true);
    }
}

[System.Serializable]
public class UIElement
{
    public string name;   
    public GameObject ui;
    public bool IsActive = false;
    public UIControl uIControl;
    
    public bool GetActive()
    {
        return IsActive;
    }

    public void SetActive(bool active)
    {
        IsActive= active;
        EnabelUiElement(active, uIControl);
    }   

    private void EnabelUiElement(bool active,UIControl control)
    {
        if (control.UseAnimation)
        {
            if (active)
            {
                control.animator.SetTrigger(control.triggerEnabelName);
            }
            else if (!active)
            {
                control.animator.SetTrigger(control.triggerDisabelName);
            }
            return;
        }

        ui.SetActive(active);
    }
}

[System.Serializable]
public class UIControl
{
    public bool UseAnimation;
    public Animator animator;
  
    public string triggerEnabelName;
    public string triggerDisabelName;
}