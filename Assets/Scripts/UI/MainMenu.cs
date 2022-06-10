using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _highScore = null;
    [SerializeField] private Text _title = null;
    [SerializeField] private Text _version = null;

    string path = "Assets/StreamingAssets/Data.json";
    // Start is called before the first frame update
    void Start()
    {
        _highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        GetData();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    void GetData()
    {
        StreamReader reader = new StreamReader(path);
        string dataString = reader.ReadToEnd();
        Debug.Log(dataString);
        Data data = JsonUtility.FromJson<Data>(dataString);
        if (_title != null)
            _title.text = data.Title;
        if (_version != null)
            _version.text = data.Version;

        PlayerPrefs.SetInt("GameSession", data.GameSession);

        // saves spawn pumpkin index array as string
        PlayerPrefs.SetString("Pumpkins", string.Join(",", data.Pumpkins));
        reader.Close();
    }
}
