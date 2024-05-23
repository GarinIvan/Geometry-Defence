using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public EnemyBullet bulletPrefab;
    public Transform[] bulletSpawnPosition;
    public float interval = 1f;
    public float damage;
    private float timer = 0f;
    private void FixedUpdate()
    {
        ShotFind();
    }

    public void ShotFind()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            Shot();
        }
    }

    private void Shot()
    {
        for (int i = 0; i < bulletSpawnPosition.Length; i++)
        {
            EnemyBullet newEnemyBullet = Instantiate(bulletPrefab, bulletSpawnPosition[i].position, bulletSpawnPosition[i].rotation).GetComponent<EnemyBullet>();
            newEnemyBullet.SetEnemy(gameObject);
        }
    }
}
