using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public float speed;
    void FixedUpdate()
    {
        EnemyMove();
    }
    public void EnemyMove()
    {
        transform.Translate(Vector3.left * Time.fixedDeltaTime * speed);
    }
}
