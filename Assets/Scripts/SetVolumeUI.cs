using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolumeUI : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    // Start is called before the first frame update
    public void SetAmbienceLvl(float vol)
    {
        _mixer.SetFloat("AmbienceVol", vol);
    }
}
