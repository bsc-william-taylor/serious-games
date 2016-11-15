using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class VideoPlayer : MonoBehaviour
{
    public MovieTexture movTexture;

    void Start()
    {
        var componentRenderer = GetComponent<Renderer>();
        var audioSource = GetComponent<AudioSource>();

        if (componentRenderer != null && audioSource != null)
        {
            componentRenderer.material.mainTexture = movTexture;
            audioSource.clip = movTexture.audioClip;
      
            audioSource.Play();
            movTexture.Play();

            StartCoroutine(WaitForMovie(movTexture));
        }
        else
        {
            Debug.LogError("Error Renderer || AudioSource is null");
        }
    }

    IEnumerator WaitForMovie(MovieTexture texture)
    {
        yield return new WaitForSeconds(texture.duration);
        
        // ... Handle when the texture is finished   
    }
}
