using UnityEngine;

public class BombFruit : Fruit
{
    public void InitBomb()
    {
        Score = -10;
        Time = -10f;
    }
    public override void OnSliced(Player player)
    {
        player.AddScore(this.Score);
    }

    public override void OnSliced(Player player, int hitCount)
    {
        throw new System.NotImplementedException();
    }
}
