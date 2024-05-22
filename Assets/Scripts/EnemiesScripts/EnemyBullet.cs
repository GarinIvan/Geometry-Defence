using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    private float damage = 10;
    public ParticleSystem boom;
    public GameObject hitSound;
    private GameObject turret;

    private void Start()
    {
        Invoke("DestroyFireball", lifeTime);
    }

    void FixedUpdate()
    {
        MovedFixedUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        TurretDamage(other);
    }

    public void MovedFixedUpdate()
    {
        transform.position -= transform.forward * speed * Time.fixedDeltaTime;
    }

    public void SetEnemy(GameObject newEnemy)
    {
        turret = newEnemy;
        damage = turret.GetComponent<ShootingEnemy>().damage;
    }

    private void DestroyFireball()
    {
        Instantiate(boom, transform.position, transform.rotation);
        Instantiate(hitSound);
        Destroy(gameObject);
    }

    private void TurretDamage(Collider other)
    {
        var turretHealth = other.gameObject.GetComponent<Building>();
        if (turretHealth != null)
        {
            DestroyFireball();
            turretHealth.health -= damage;
            if (turretHealth.health <= 0)
            {
                Destroy(turretHealth.gameObject);
            }
        }
    }
}