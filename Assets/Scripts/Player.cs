using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    [field: SerializeField] private TextMeshProUGUI scoreText;
    [field: SerializeField] private TextMeshProUGUI timeText;
    [field: SerializeField] private int totalScore;

    [field: SerializeField] private float startPlayTime = 30f;
    public int TotalScore { get => totalScore; set => totalScore = value; }

    private float playtime;
    public float Playtime { get => playtime; set => playtime = (value < 0) ? 0 : value; }

    private void Start()
    {
        Playtime = startPlayTime;
        ResetScore();
        UpdateTimeUI();
    }

    private void Update()
    {
        if (Playtime > 0)
        {
            Playtime -= Time.deltaTime;
            UpdateTimeUI();

        }
        else
        {
            Playtime = 0;
            LoadGameOver();
            return;
        }
    }

    private void LoadGameOver()
    {
        ScoreData.FinalScore = this.totalScore;

        SceneManager.LoadScene("EndGame");
    }

    public void AddScore(int amount)
    {
        TotalScore = Mathf.Max(0, TotalScore + amount);
        UpdateScoreUI();
    }
    public void AddScore(int amount, bool isCritical)
    {
        if (isCritical)
        {
            totalScore = Mathf.Max(0, totalScore + amount * 2);
        }
        else
        {
            AddScore(amount);
        }
        UpdateScoreUI();
    }
    public void AddTime(float amount)
    {
        Playtime = Mathf.Max(0f, Playtime + amount);
    }
    public void Slice(Fruit fruit)
    {
        fruit.OnSlice(this);
    }
    public void Slice(Fruit fruit, Vector2 hitDirection)
    {
        fruit.OnSlice(this, hitDirection);
    }
    public void ResetScore()
    {
        TotalScore = 0;
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + TotalScore;
        }
    }
    private void UpdateTimeUI()
    {
        if (timeText != null)
        {
            timeText.text = "Time: " + Mathf.CeilToInt(Playtime);
        }
    }
}
