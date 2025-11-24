using UnityEngine;

public class BombFruit : Fruit
{
    [field: SerializeField] private int penaltyScore = 20;
    [field: SerializeField] private float penaltyTime = 2f;

    public override void OnSlice(Player player)
    {
        if (sliced) return;
        sliced = true;
        player.AddScore(-penaltyScore);
        player.AddTime(-penaltyTime);
        OnSlicedVisual();
        FruitDestroy();
    }
    public override void OnSlice(Player player, Vector2 hitDirection)
    {
        OnSlice(player);
    }
    protected override void OnSlicedVisual()
    {
        
    }
}
