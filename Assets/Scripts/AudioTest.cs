using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTest : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();
    private List<AudioSource> _audioSources = new List<AudioSource>();

    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private float fadeDuration;

    [SerializeField] private String exposedParam;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var audioClip in _audioClips)
        {
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            _audioSources.Add(audioSource);
            audioSource.outputAudioMixerGroup = _audioMixerGroup;
        }

        /*AudioSource[] list = GetComponents<AudioSource>();
        foreach (var audioSource in list)
        {
            _audioSources.Add(audioSource);
            audioSource.outputAudioMixerGroup = _audioMixerGroup;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayAudiosources();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(StopAudiosource());
        }
    }
    
    private void PlayAudiosources()
    {
        StartCoroutine(FadeMixerGroup.StartFade(_mixer, exposedParam, fadeDuration, 1));
        foreach (var audioSource in _audioSources)
        {
            audioSource.Play();
        }
    }
    
    private IEnumerator StopAudiosource()
    {
        StartCoroutine(FadeMixerGroup.StartFade(_mixer, exposedParam, fadeDuration, 0));
        yield return new WaitForSeconds(fadeDuration);
        foreach (var audioSource in _audioSources)
        {
            audioSource.Stop();
        }
    }
}
