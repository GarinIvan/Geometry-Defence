using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject secondEnemy;
    public ParticleSystem deathEffect;
    public void OnDestroy()
    {
        Instantiate(secondEnemy, transform.position, transform.rotation);
        Instantiate(deathEffect, transform.position, transform.rotation);
    }
}
