using UnityEngine;

public class Boom : MonoBehaviour
{
    public AudioSource collisionSound;
    public GameObject explosionPrefab;
    public Transform explosionParticle;
    public Building color;
    private bool isBuildingReady = false;
    public float time;

    void Start()
    {
        color = GetComponent<Building>();
        color.SetColor(true); // Устанавливаем цвет заранее
        isBuildingReady = true;
    }

    private void FixedUpdate()
    {
        if (isBuildingReady)
        {
            ExplosionFind();
        }
    }

    void ExplosionFind()
    {
        if (color._renderer.material.color == color.colorMaterial)
        {
            Invoke("Explosion", time);
        }
    }

    private void Explosion()
    {
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        var explosionPart = Instantiate(explosionParticle);
        explosionPart.transform.position = transform.position;
        Destroy(gameObject);
    }
}

