using UnityEngine;

public class BombFruit : Fruit
{
    [field: SerializeField] private int penaltyScore = 20;
    [field: SerializeField] private float penaltyTime = 2f;

    [field: SerializeField] private ParticleSystem bombParticles;
    [field: SerializeField] private AudioClip bombSound;

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
        if (bombParticles != null)
        {
            var ps = Instantiate(bombParticles, transform.position, Quaternion.identity);
            ps.Play();
            Destroy(ps.gameObject, ps.main.duration);
        }
        AudioManager.Instance.PlaySound(bombSound);
    }
}
