using System;
using UnityEngine;

public class Base : MonoBehaviour
{
    public GameObject youWon;
    public ParticleSystem explosion;
    public Animator mainCamera;
    public float increaseAmount = 10f;
    public float interval = 1f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            ValueCounter.value += increaseAmount;
        }
    }
    public void DestroyBase()
    {
        mainCamera.SetTrigger("Won");
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        youWon.SetActive(true);
    }
}
