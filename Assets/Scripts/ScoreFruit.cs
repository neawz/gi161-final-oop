using UnityEngine;

public class ScoreFruit : Fruit
{
    public override void OnSlice(Player player)
    {
        player.AddScore(this.Score);
    }
    public override void OnSlice(Player player, int hitCount)
    {
        throw new System.NotImplementedException();
    }
}