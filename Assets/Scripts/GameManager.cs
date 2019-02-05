using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsGameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        IsGameOver = false;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void StartGame()
    {
        UIManager.Instance.GameStart();
        ScoreManager.Instance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawning();
    }

    public void GameOver()
    {
        UIManager.Instance.GameOver();
        ScoreManager.Instance.StopScore();
    }
}
