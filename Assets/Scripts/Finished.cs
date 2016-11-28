using UnityEngine;
using SimpleJSON;

public class Finished : MonoBehaviour
{
    public bool FailedScene = false;
    public string Url;

    void Start()
    {
        if (string.IsNullOrEmpty(Url))
            return;

        if (FailedScene)
        {
            PresentVideo();
        }


        WebService.EndGameplay(this, Url);
    }

    void PresentVideo()
    {
        
    }
}
