using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AudioManager : MonoBehaviour
{
    public SoundGroupManager groupManager;
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddSoundControler(SoundControler soundControler)
    {
        SoundGroupOld group = soundControler.soundGroup;

        if (groupManager.GetSoundGroup(group, out SoundGroupInfo soundGroup))
        {
            soundGroup.AddSoundControler(soundControler);
        }
        else
        {
            SoundGroupInfo newSoundGroup = new SoundGroupInfo(group, soundControler);
            groupManager.AddSoundGroup(newSoundGroup);
        }
    }

    public void ChangeSoundVolume(SoundGroupOld soundGroup, float newVolume)
    {
        if (groupManager.GetSoundGroup(soundGroup, out SoundGroupInfo groupInfo))
        {
            groupInfo.ChangeVolume(newVolume);
        }
    }

    public void PlaySound(SoundGroupOld soundGroup, string soundName)
    {
        if (GetControler(soundGroup, soundName, out SoundControler soundControler))
        {
            soundControler.PlaySound();
        }
    }

    public void PlaySound(AudioClip clip, SoundGroupOld soundGroup)
    {
        GameObject soundContainer = new GameObject();

        AudioSource audioSource = soundContainer.AddComponent<AudioSource>();
        soundContainer.AddComponent<SoundControler>();
        DestroyOnTime destroy = soundContainer.AddComponent<DestroyOnTime>();

        audioSource.clip = clip;
        destroy.destroyTime = clip.length;
    }

    public void StoppPlay(SoundGroupOld soundGroup, string soundName)
    {
        if (GetControler(soundGroup, soundName, out SoundControler soundControler))
        {
            soundControler.PlaySound();
        }
    }

    private bool GetControler(SoundGroupOld soundGroup, string soundName, out SoundControler soundControler)
    {
        if (groupManager.GetSoundGroup(soundGroup, out SoundGroupInfo groupInfo))
        {
            if (groupInfo.GetSoundControler(soundName, out SoundControler controler))
            {
                soundControler = controler;
                return true;
            }
            else
            {
                soundControler = null;
                return false;
            }
        }
        else
        {
            soundControler = null;
            return false;
        }
    }
}
   
   
[Serializable]
public class SoundGroupManager
{
    public List<SoundGroupInfo> SoundGroups;
    
    public void AddSoundGroup(SoundGroupInfo soundGroupInfo)
    {
        SoundGroups.Add(soundGroupInfo);
    }

    public bool GetSoundGroup(SoundGroupOld soundGroup,out SoundGroupInfo groupInfo)
    {
        groupInfo = null;

        foreach (var item in SoundGroups)
        {
            if (item.SoundGroup == soundGroup)
            {
                groupInfo = item;
                return true;
            }
        }

        return false;
    }
}

[System.Serializable]
public class SoundGroupInfo
{
    public SoundGroupInfo(SoundGroupOld group)
    {
        SoundGroup = group;
        SoundControlers = new List<SoundControler>();
        SoundGroupVolume = SoundGroupVolumeSaver.GetSoundGroupVolume(group);
    }

    public SoundGroupInfo(SoundGroupOld group,SoundControler soundControler)
    {
        SoundGroup = group;

        SoundControlers = new List<SoundControler>();
        AddSoundControler(soundControler);

        SoundGroupVolume = SoundGroupVolumeSaver.GetSoundGroupVolume(group);
    }

    public SoundGroupOld SoundGroup;
    public List<SoundControler> SoundControlers; 
    public float SoundGroupVolume;
    public event UnityAction<float> onValueChanged;

    public void AddSoundControler(SoundControler controler)
    {
        SoundControlers.Add(controler);
        onValueChanged += controler.ChangeSoundVolume;
    }

    public void ChangeVolume(float newVolume)
    {
        onValueChanged?.Invoke(newVolume);
        SoundGroupVolume = newVolume;
    }

    public bool GetSoundControler(string name, out SoundControler soundControler)
    {
        foreach (var item in SoundControlers)
        {
            if (item.name == name)
            {
                soundControler = item;
                return true;
            }
        }

        soundControler = null;
        return false;
    }
}

public static class SoundGroupVolumeSaver
{
    public static float GetSoundGroupVolume(SoundGroupOld soundGroup)
    {
        string soundGroupAsString = soundGroup.ToString();
        if (PlayerPrefs.HasKey(soundGroupAsString))
        {
            return PlayerPrefs.GetFloat(soundGroupAsString);
        }
        return 1;
    }

    public static void SaveAudioVolume(SoundGroupOld soundGroup, float soundVolume)
    {
        string soundGroupAsString = soundGroup.ToString();
        PlayerPrefs.SetFloat(soundGroupAsString, soundVolume);
    }
}
   
