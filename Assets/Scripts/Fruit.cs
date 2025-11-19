using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    private int score;
    public int Score { get => score; set => score = value; }

    private float time;
    public float Time { get => time; set => time = value; }

    public abstract void OnSlice(Player player);
    public abstract void OnSlice(Player player, int hitCount);
}
