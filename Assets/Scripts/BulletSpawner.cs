using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float initialSpeed = 50f;
    [SerializeField] private float timeBetweenSpawns = 20f;
    [SerializeField] private float speedIncreaseRate = 0.5f;

    private float nextSpawnTime = 1.5f;
    private ParticleSystem part;

    private void Awake()
    {
        part = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnBullet();
            nextSpawnTime = Time.time + timeBetweenSpawns;
            initialSpeed += speedIncreaseRate;
        }
    }

    private void SpawnBullet()
    {
        float randomY = Random.Range(-7f, 15f);
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(-31f, randomY, 0f), Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * initialSpeed;
        Destroy(bullet, 10f);
    }
}
