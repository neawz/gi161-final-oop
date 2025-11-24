using UnityEngine;

public class BombFruit : Fruit
{
    [field: SerializeField] private int penaltyScore = 20;
    [field: SerializeField] private float penaltyTime = 2f;

    public override int GetScore()
    {
        return 0;
    }

    public override void OnSlice(Player player)
    {
        if (Sliced) return;
        Sliced = true;
        //Penalty
        player.AddScore(-penaltyScore);
        player.AddTime(-penaltyTime);

        OnSlicedVisual();
        FruitDestroy();
    }
}
