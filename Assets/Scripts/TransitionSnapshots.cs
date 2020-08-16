using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TransitionSnapshots : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot normal, underwater;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            normal.TransitionTo(2f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            underwater.TransitionTo(2);
        }
    }
}
