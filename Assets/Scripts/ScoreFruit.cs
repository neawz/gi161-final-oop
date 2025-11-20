using UnityEngine;

public class ScoreFruit : Fruit
{
    [field: SerializeField] private int bonusPerHit;

    public override int GetScore()
    {
        return Score;
    }

    public override void OnSlice(Player player, int hitCount)
    {
        if (Sliced)
        {
            return;
        }
        Sliced = true;

        int totalGetScore = GetScore() + bonusPerHit * Mathf.Max(0, hitCount - 1);
        player.AddScore(totalGetScore);
        player.AddTime(PlayTime);
        OnSlicedVisual();
        FruitDestroy();
    }
}