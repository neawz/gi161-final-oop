using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private Fruit[] fruitPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float launchForce = 8f;
    [SerializeField] private float randomAngle = 30f;
    [SerializeField] private float spawnInterval = 0.8f;

    private float nextTime;

    private void Update()
    {
        if (Time.time >= nextTime)
        {
            SpawnFruit();
            nextTime = Time.time + spawnInterval;
        }
    }
    public void SpawnFruit()
    {
        if (fruitPrefabs.Length == 0 || spawnPoints.Length == 0) return;
        var prefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
        var point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        var fruit = Instantiate(prefab, point.position, Quaternion.identity);
        var rb = fruit.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float angle = Random.Range(-randomAngle, randomAngle);
            Vector2 dir = Quaternion.Euler(0, 0, angle) * Vector2.up;
            rb.linearVelocity = dir * launchForce;
        }
    }
}
