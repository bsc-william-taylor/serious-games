using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using SimpleJSON;

public class WebService : MonoBehaviour
{
    private const string Server = "http://localhost:8080";

    public static IEnumerator<WWW> Get(string url, Action<JSONNode> action)
    {
        var www = new WWW(Server + url);
        yield return www;
        action(JSON.Parse(www.text));
    }

    public static IEnumerator<WWW> Post(string url, JSONClass json, Action<JSONNode> action)
    {
        var bytes = Encoding.UTF8.GetBytes(json.ToString());
        var headers = new Dictionary<string, string>
        {
            {"Content-Type", "application/json"}
        };

        var request = new WWW(Server + url, bytes, headers);
        yield return request;
        action(JSON.Parse(request.text));
    }
}
