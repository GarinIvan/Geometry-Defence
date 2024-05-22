using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public EnemyBullet bulletPrefab;
    public Transform bulletSpawnPosition;
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
        EnemyBullet newEnemyBullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation).GetComponent<EnemyBullet>();
        newEnemyBullet.SetEnemy(gameObject);
    }
}
