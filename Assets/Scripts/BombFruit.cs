using UnityEngine;

public class BombFruit : Fruit
{
    [field: SerializeField] private ParticleSystem bombParticles;
    [field: SerializeField] private AudioClip bombSound;

    public void Awake()
    {
        Score = 5;
        Playtime = 2f;
    }
    public override void OnSlice(Player player)
    {
        if (sliced) return;
        sliced = true;
        player.AddScore(-Score);
        player.AddTime(-Playtime);
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
