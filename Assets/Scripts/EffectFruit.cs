using UnityEngine;

public class EffectFruit : Fruit
{
    public void InitEffect()
    {
        Time = 10f;
    }
    public override void OnSlice(Player player)
    {
        player.AddTime(this.Time);
    }

    public override void OnSlice(Player player, int hitCount)
    {
        throw new System.NotImplementedException();
    }
}
