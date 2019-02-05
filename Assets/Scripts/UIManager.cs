using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject welcomePanel;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject tapText;
    [SerializeField] private Text score;
    [SerializeField] private Text highScore1;
    [SerializeField] private Text highScore2;

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
        highScore1.text = "Highscore: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void GameStart()
    {
        highScore1.text = PlayerPrefs.GetInt("highScore").ToString();
        tapText.SetActive(false);
        welcomePanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameoverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
