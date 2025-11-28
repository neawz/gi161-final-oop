using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreFruit : Fruit
{
    [field: SerializeField] private ParticleSystem scoreParticles;
    [field: SerializeField] private AudioClip sliceSound;

    public override int GetScore()
    {
        return Score;
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
        // Particle
        if (scoreParticles != null)
        {
            var ps = Instantiate(scoreParticles, transform.position, Quaternion.identity);
            ps.Play();
            Destroy(ps.gameObject, ps.main.duration);
        }
        AudioManager.Instance.PlaySound(sliceSound);
    }
}