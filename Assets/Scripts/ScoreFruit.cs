using UnityEngine;

public class ScoreFruit : Fruit
{
    [field:SerializeField] private int bonusPerHit ;
    public override void OnSlice(Player player, int hitCount)
    {
        if(Sliced)
        {
            return;
        }
        Sliced = true;

        int totalGetScore = GetSocre() + bonusPerHit * Mathf.Max(0, hitCount - 1);
        player.AddScore(totalGetScore);
        player.AddTime(Time);
        OnSlicedVisual();
        FruitDestroy();
    }
}