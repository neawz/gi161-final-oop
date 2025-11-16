using UnityEngine;

public class Player : MonoBehaviour
{
    private int totalScore;
    private float time;

    public int AddScore(int score)
    {
        totalScore += score;
        return score;
    }
    public float AddTime(float time)
    {
        time += time;
        return time;
    }
    public void Slice()
    {

    }
}
