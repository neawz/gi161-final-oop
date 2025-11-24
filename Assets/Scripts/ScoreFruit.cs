using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreFruit : Fruit
{
    [SerializeField] private int bonus = 2;

    public override int GetScore()
    {
        return Score + bonus;
    }
    public override void OnSlice(Player player)
    {
        base.OnSlice(player);
    }
    public override void OnSlice(Player player, Vector2 hitDirection)
    {
        base.OnSlice(player, hitDirection);
    }
    protected override void OnSlicedVisual()
    {
        
    }
}