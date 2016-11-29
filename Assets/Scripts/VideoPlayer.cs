﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(AudioSource))]
public class VideoPlayer : MonoBehaviour, IPointerClickHandler
{
    public MovieTexture movTexture;
    public bool PlayOnLoad;

    private AudioSource audioSource;

    void Start()
    {
        TryLoad();
    }

    public void TryLoad()
    {
        var rawImage = GetComponent<RawImage>();
        audioSource = GetComponent<AudioSource>();

        if (rawImage != null && audioSource != null && movTexture != null)
        {
            rawImage.texture = movTexture;
            audioSource.clip = movTexture.audioClip;

            if (PlayOnLoad)
            {
                audioSource.Play();
                movTexture.Play();
            }

            StartCoroutine(WaitForMovie(movTexture));
        }
    }

    IEnumerator WaitForMovie(MovieTexture texture)
    {
        yield return new WaitForSeconds(texture.duration);

        audioSource.Stop();
        movTexture.Stop();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!movTexture.isPlaying)
        {
            audioSource.Play();
            movTexture.Play();
        }
        else
        {
            audioSource.Pause();
            movTexture.Pause();
        }
    }
}
