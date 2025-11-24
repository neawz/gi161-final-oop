using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    private int score;
    public int Score { get => score; set => score = (value < 0) ? 0 : value; }

    private float playTime;
    public float PlayTime { get => playTime; set => playTime = (value < 0) ? 0 : value; }

    private bool sliced;
    protected bool Sliced { get => sliced; set => sliced = value; }
    private void FixedUpdate()
    {
        Destroy(this.gameObject, 5f);
    }
    public abstract int GetScore();
    public virtual void OnSlice(Player player)
    {
        if (Sliced) return;
        Sliced = true;
        player.AddScore(GetScore());
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
}
