using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
    public string name;
    public SoundGroupOld soundGroup;
    public AudioSource audioSource;
    public bool isPlaying;

    private void Awake()
    {
        if(audioSource != null)        
            audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().AddSoundControler(this);
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }

    public float GetClipLength()
    {
        return audioSource.clip.length;
    }
    
    public void ChangeSoundVolume(float newVolume)
    {
        if(audioSource != null)
        audioSource.volume = newVolume;       
        Debug.Log($"Audio von {name} Geändert Auf: " + newVolume);
    }

    public void PlaySound()
    {      
        audioSource.Play();
    }

    public void StopPlay()
    {
        audioSource.Stop();
    }   
}
