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

        var body = new JSONClass();
        body["gameplayID"] = new JSONData(WebService.GameplayID);
        StartCoroutine(WebService.Post(Url, body, (json, err) =>
        {
            WebService.ResetState();
        }));
    }

    void PresentVideo()
    {
        
    }
}
