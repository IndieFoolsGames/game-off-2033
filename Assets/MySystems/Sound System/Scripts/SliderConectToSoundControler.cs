using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderConectToSoundControler : MonoBehaviour
{
    public SoundGroupOld soundGroup;
    public AudioManager soundManager;
    Slider slider;

    private void Start()
    {
       if(soundManager == null)
       {
            soundManager = FindObjectOfType<AudioManager>();
       }
       slider = GetComponent<Slider>();        
    }

    public void ChangeVolume(Slider slider)
    {
        soundManager.ChangeSoundVolume(soundGroup,GetSliderValue(slider));
    }

    float GetSliderValue(Slider slider)
    {
        return slider.value;
    }
    
    

}
