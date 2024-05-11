using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float originalSpeed = 0.075f;
    private float speed;
    public float damage = 5;
    public float reload;
    private Building _targetBuilding;
    private Animator _animator;
    private static readonly int IsAttack = Animator.StringToHash("isAttack");

    void Start()
    {
        StartEnemy();
    }
    void FixedUpdate()
    {
        EnemyMove();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            Building building = other.GetComponent<Building>();
            if (building != null)
            {
                _targetBuilding = building;
                _animator.SetBool(IsAttack, true);
                speed = 0;
            }
        }
    }
    public void AttackBuilding()
    {
        if (_targetBuilding != null)
        {
            _targetBuilding.TakeDamage(damage);
        }
        else
        {
            _targetBuilding = null;
            _animator.SetBool(IsAttack, false);
            speed = originalSpeed;
        }
    }
    public void EnemyMove()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    public void StartEnemy()
    {
        transform.rotation = Quaternion.Euler(0, -90, 0);
        speed = originalSpeed;
        _animator = GetComponentInChildren<Animator>();
    }
}