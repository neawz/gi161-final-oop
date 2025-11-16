using UnityEngine;

public class ScoreFruit : Fruit
{
    public override void OnSliced(Player player)
    {
        player.AddScore(this.Score);
    }
    public override void OnSliced(Player player, int hitCount)
    {
        throw new System.NotImplementedException();
    }
}