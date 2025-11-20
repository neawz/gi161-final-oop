using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    private int score;
    public int Score { get => score; set => score = value; }

    private float playTime;
    public float PlayTime { get => playTime; set => playTime = value; }

    private bool sliced;
    protected bool Sliced { get => sliced; set => sliced = value; } 
    public virtual int GetScore()
    {
        return Score;
    }
    public virtual void OnSlice(Player player)
    {
        if (Sliced)
        {
            return;
        }
        sliced = true;
        player.AddScore(GetScore());
        player.AddTime(PlayTime);
        OnSlicedVisual();
        FruitDestroy();
    }

    public virtual void OnSlice(Player player, int hitCount)
    {
        if (Sliced)
        {
            return;
        }
        Sliced = true;
        int normalScore = GetScore();
        float comboMutiplier = 1f + Mathf.Max(0, hitCount - 1) * 0.1f;

        player.AddScore(Mathf.RoundToInt(normalScore * comboMutiplier));
        player.AddTime(PlayTime);
        OnSlicedVisual();
        FruitDestroy();
    }
    protected virtual void OnSlicedVisual()
    {
        // Play sound, play animation or add effect.bla bla bla 
    }
    protected virtual void FruitDestroy()
    {
        Destroy(this.gameObject);
    }
    private void FixedUpdate()
    {
        Destroy(this.gameObject, 3f);
    }
}
