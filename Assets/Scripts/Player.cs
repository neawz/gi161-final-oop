using UnityEngine;

public class Player : MonoBehaviour
{
    private int totalScore;
    public int TotalScore
    {
        get => totalScore; set => totalScore = value;
    }
    private float timed;
    public float Timed
    {
        get => timed; set => timed = value;
    }

    [SerializeField] private float comboWindow = 0.5f;
    [SerializeField] private int comboHits;
    [SerializeField] private float lastSliceTime;

    public void AddScore(int amount)
    {
        TotalScore += Mathf.Clamp(amount,0, TotalScore + amount);
    }
    public void AddTime(float amount)
    {
        Timed += Mathf.Clamp(amount, 0, Timed + amount);
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
        Slice();
        fruit.OnSlice(this, hitCountForThisStrike);
    }
}
