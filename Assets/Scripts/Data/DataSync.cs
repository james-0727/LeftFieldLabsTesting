using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public struct Data
{
    public string Title;
    public string Version;
}
public class DataSync : MonoBehaviour
{
    [SerializeField] private Text _title = null;
    [SerializeField] private Text _version = null;

    string jsonURL = "https://drive.google.com/uc?export=download&id=1ipruV0QwBm11Iiia2GqQsdEhclEBzWsK";

    void Start()
    {
        StartCoroutine(GetData(jsonURL));
    }
    IEnumerator GetData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.Send();

        if(request.isNetworkError)
        {
            // error...
        } else
        {
            Data data = JsonUtility.FromJson<Data>(request.downloadHandler.text);
            _title.text = data.Title;
            _version.text = data.Version;
        }
    }
}
