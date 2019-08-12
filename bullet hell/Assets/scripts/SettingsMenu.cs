using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer musicmixer;
    
    public void SetVolume (float volume)
    {
        musicmixer.SetFloat("Volume", volume);

    }

}
