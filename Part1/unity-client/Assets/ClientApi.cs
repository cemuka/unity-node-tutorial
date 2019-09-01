using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ClientApi : MonoBehaviour
{
    public string url;

    void Start()
    {
        StartCoroutine(Get(url));
    }

    public IEnumerator Get(string url)
    {
        using(UnityWebRequest www = UnityWebRequest.Get(url)){
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
                    Debug.Log(result);
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
