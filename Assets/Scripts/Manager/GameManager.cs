using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int score = 0;
    private WaveManager waveManager;
    private PlayerStats playerStats;
    private Text scoreUI;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        
        Text[] allTexts = FindObjectsOfType<Text>();
        foreach (Text t in allTexts)
        {
            if (t.name == "ScoreText") scoreUI = t;
        }
    }

    public void AddScore(int points)
    {
        score += points;
        if (scoreUI != null)
        {
            scoreUI.text = "Score: " + score;
        }
    }
}
