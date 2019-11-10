using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ClientApi : MonoBehaviour
{
    public string getUrl = "localhost:3000/enemy";
    public string postUrl = "localhost:3000/enemy/create";

    public void GetRequest(string url, System.Action<string> callback)
    {
        StartCoroutine(Get(url,callback));
    }
 
    private IEnumerator Get(string url, System.Action<string> callback)
    {
        using(UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    //handle result
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data); 
                    //format json to be able to work with JsonUtil 
                    result = "{\"result\":" + result + "}"; 

                    callback(result);
                }
                else
                {
                    //handle the problem
                    Debug.Log("Error! data couldn't get.");
                }
            }
        }
    }

    public void PostRequest(string url, EnemyRequestData data, System.Action<string> callback)
    {
        StartCoroutine(Post(url,data,callback));
    }

    private IEnumerator Post(string url, EnemyRequestData data, System.Action<string> callback)
    {
        var jsonData = JsonUtility.ToJson(data);
        Debug.Log(jsonData);
        using(UnityWebRequest www = UnityWebRequest.Post(url, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    // handle the result
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);  
                    result = "{\"result\":" + result + "}"; 
                    
                    callback(result);
                }
                else
                {
                    //handle the problem
                    Debug.Log("Error! data couldn't get.");
                }
            }
        }
    }


}
