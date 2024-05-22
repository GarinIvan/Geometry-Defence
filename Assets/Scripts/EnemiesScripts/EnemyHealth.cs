using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public ParticleSystem deathEffect;
    public AudioSource enemyDeathSound;
    public void DestroyEnemy()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(enemyDeathSound);
        Destroy(gameObject);
    }
}
