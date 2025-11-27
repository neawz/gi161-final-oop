using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    private int score = 3;
    public int Score { get => score; set => score = (value < 0) ? 0 : value; }

    private float playTime;
    public float PlayTime { get => playTime; set => playTime = (value < 0) ? 0 : value; }
    protected bool sliced;

    private void FixedUpdate()
    {
        Destroy(this.gameObject, 5f);
    }
    public virtual int GetScore()
    {
        return Score;
    }
    public virtual void OnSlice(Player player)
    {
        if (sliced) return;
        sliced = true;
        player.AddScore(GetScore());
        player.AddTime(PlayTime);
        OnSlicedVisual();
        FruitDestroy();
    }
    public virtual void OnSlice(Player player, Vector2 hitDirection)
    {
        if (sliced) return;
        sliced = true;
        bool isCritical = hitDirection.y < -0.5f;
        player.AddScore(GetScore(), isCritical);
        player.AddTime(PlayTime);
        OnSlicedVisual();
        FruitDestroy();
    }
    protected abstract void OnSlicedVisual();
    protected virtual void FruitDestroy()
    {
        Destroy(this.gameObject);
    }
}
