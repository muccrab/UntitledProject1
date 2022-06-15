using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void music_volume(float music)//nastavenie zvuky cez slider pre musicu
    {
        audioMixer.SetFloat("Music", music);
    }

    public void sfx_volume(float sfx)//nastavenie zvuky cez slider pre fx zvuky
    {
        audioMixer.SetFloat("SFX", sfx);
    }
}
