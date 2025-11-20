using UnityEngine;

public class EffectFruit : Fruit
{
    public void InitEffect()
    {
        PlayTime = 10f;
    }
    public override void OnSlice(Player player)
    {
        player.AddTime(this.PlayTime);
    }

    public override void OnSlice(Player player, int hitCount)
    {
        throw new System.NotImplementedException();
    }
}
