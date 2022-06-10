using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public System.Action OnSessionStart;
    public System.Action OnSessionEnd;

    public float timeLeft = 0;

    [SerializeField]
    private HUD _mainUI;
    private int currentScore = 0;
    private int highScore = 0;

    public static GameSession _instance;

    [SerializeField]
    private EnemySpawner [] spawners;
    public static GameSession Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game static instance was accessed before it could be initialized!");

            return _instance;
        }
    }
    public enum SessionState
    {
        Paused,
        Active,
        Finished
    }

    private SessionState _state = SessionState.Paused;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // load data
        LoadData();
        StartSession();
    }


    // Update is called once per frame
    void Update()
    {
        if( _state == SessionState.Active )
        {
            timeLeft -= Time.deltaTime;
            
            if( timeLeft <= 0 )
            {
                timeLeft = 0;
                EndSession();
            }
        }
    }

    void LoadData()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        timeLeft = PlayerPrefs.GetInt("GameSession", 60);
        var tmpString = PlayerPrefs.GetString("Pumpkins", "1,2,3");
        var pumpkinIndexArray = tmpString.Split(',');
        for (int i = 0; i < pumpkinIndexArray.Length; i++)
            spawners[i].gameObject.SetActive(true);
    }

    void StartSession()
    {
        _state = SessionState.Active;

        if( OnSessionStart != null )
        {
            OnSessionStart();
        }
        Time.timeScale = 1;
    }

    void EndSession()
    {
        if( OnSessionEnd != null )
        {
            OnSessionEnd();
        }
        Time.timeScale = 0;
    }

    public void AddScore()
    {
        currentScore++;
        if (highScore < currentScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        _mainUI.SetScoreValue(currentScore);

    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
