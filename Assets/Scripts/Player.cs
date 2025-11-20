using UnityEngine;

public class Player : MonoBehaviour
{
    private int totalScore;
    public int TotalScore
    {
        get => totalScore; set => totalScore = value;
    }

    private float playTime;
    public float PlayTime
    {
        get => playTime; set => playTime = value;
    }

    [field: SerializeField] private float comboWindow = 0.5f;
    [field: SerializeField] private int comboHits;
    [field: SerializeField] private float lastSliceTime;

    public void AddScore(int amount)
    {
        TotalScore += Mathf.Clamp(amount,0, TotalScore + amount);
    }
    public void AddTime(float amount)
    {
        PlayTime += Mathf.Clamp(amount, 0, PlayTime + amount);
    }
    public void Slice()
    {
        float now = Time.time;
        if (now - lastSliceTime <= comboWindow)
        {
            comboHits++;
        }
        else
        {
            comboHits = 1;
            lastSliceTime = now;
        }
    }
    public void ApplySlice(Fruit fruit, int hitCountForThisStrike)
    {
        Debug.Log("ApplySlice");
        Slice();
        fruit.OnSlice(this, hitCountForThisStrike);
    }
}
