using System;
using System.Collections;
using UnityEngine;

public class TurretDestroyer : MonoBehaviour
{
    public float lifeTime;
    public ParticleSystem boom;
    public Building color;
    public GameObject destroySound;
    private bool isBuildingReady = false;
    private void Start()
    {
        color = GetComponent<Building>();
        color.SetColor(true);
        isBuildingReady = true;
    }

    private void FixedUpdate()
    {
        if (isBuildingReady)
        {
            if (color._renderer.material.color == color.colorMaterial)
            {
                Invoke("DestroyTurret", lifeTime);
            }
        }
    }

    void DestroyTurret()
    {
        Instantiate(boom, transform.position, Quaternion.Euler(-90, 0, 0));
        Instantiate(destroySound);
        Destroy(gameObject);
    }
}
