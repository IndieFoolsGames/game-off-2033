using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDisplay : MonoBehaviour
{
    public Stats stats;
    private Stat InteractionMesage;
    public InteractionPointer InteractionPointer;

    public GameObject[] mesagePanels;
    private int interactMesageIndex;
  
    private void Start()
    {       
        InteractionMesage = stats.GetStat("Interaction Mesage");

        


    }

    void SendInteractionMesage(DisplayData displayData)
    {
        string interactionMesage = displayData.mesage;              
        KeyCode keyCode = displayData.InteractionKey;
        int panelIndex = displayData.mesagePanelIndex;

        string displayMesage = "Press " + keyCode.ToString() + " " + interactionMesage; 
        InteractionMesage.ChangeValue(displayMesage);       
        ActivatMesage(panelIndex);        
    }

    public void SendMesage(DisplayData displayData)
    {
        string mesage = displayData.mesage;
        int panelIndex = displayData.mesagePanelIndex;

        InteractionMesage.ChangeValue(mesage);
        ActivatMesage(panelIndex);      
    }


    void ActivatMesage(int panelIndex)
    {
        GameObject panel = mesagePanels[panelIndex];
        panel.SetActive(true);
    }

    public void DeactivateMesage(DisplayData displayData)
    {
        GameObject panel = mesagePanels[displayData.mesagePanelIndex];
        panel.SetActive(false);
    }

    public void DeactivateMesage()
    {
        GameObject panel = mesagePanels[interactMesageIndex];
        panel.SetActive(false);
    }
}

[System.Serializable]
public struct DisplayData
{
    public int mesagePanelIndex;
    public string mesage;
    public KeyCode InteractionKey;
}

public struct InteractionData
{
    public KeyCode InteractionKey;
    public string mesage;
    public Transform mesagePanel;
}


