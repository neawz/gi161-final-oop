using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    private int score;
    public int Score { get => score; set => score = value; }

    private float time;
    public float Time { get => time; set => time = value; }

    private bool sliced;
    protected bool Sliced { get => sliced; set => sliced = value; } 
    public virtual int GetSocre()
    {
        return Score;
    }
    public virtual void OnSlice(Player player)
    {
        if(Sliced)
        {
            return;
        }
        sliced = true;
        player.AddScore(GetSocre());
        player.AddTime(Time);
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
        int normalScore = GetSocre();
        float comboMutiplier = 1f + Mathf.Max(0, hitCount - 1) * 0.1f;

        player.AddScore(Mathf.RoundToInt(normalScore * comboMutiplier));
        player.AddTime(Time);
        OnSlicedVisual();
        FruitDestroy();

    }

    protected virtual void OnSlicedVisual()
    {
        // Play sound, play animation or add effect.bla bla bla 
    }
    protected virtual void FruitDestroy()
    {
        Destroy(this);
    }
}
