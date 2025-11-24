using UnityEngine;

public class Player : MonoBehaviour
{
    [field:SerializeField] private int totalScore;
    public int TotalScore
    {
        get => totalScore; set => totalScore = value;
    }
    private float playTime;
    public float PlayTime
    {
        get => playTime; set => playTime = value;
    }

    public void AddScore(int amount)
    {
        TotalScore = Mathf.Max(0, TotalScore + amount);
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
    }
    public void AddTime(float amount)
    {
        PlayTime = Mathf.Max(0f, PlayTime + amount);
    }
    public void Slice(Fruit fruit)
    {
        fruit.OnSlice(this);
    }
    public void Slice(Fruit fruit, Vector2 hitDirection)
    {
        fruit.OnSlice(this, hitDirection);
    }
}
