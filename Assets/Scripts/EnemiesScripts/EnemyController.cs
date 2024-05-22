using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float originalSpeed = 0.075f;
    private float speed;
    public float damage = 5;
    private Building _targetBuilding;
    private Base targetBase;
    public Animator animator;
    public AudioSource attackSound;
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
                animator.SetBool(IsAttack, true);
                speed = 0;
            }
        }
        if (other.CompareTag("Base"))
        {
            Base _base = other.GetComponent<Base>();
            if(_base != null)
            {
                _base.DestroyBase();
            }
        }
    }
    public void AttackBuilding()
    {
        if (_targetBuilding != null)
        {
            _targetBuilding.TakeDamage(damage);
            Instantiate(attackSound);
        }
        else
        {
            _targetBuilding = null;
            animator.SetBool(IsAttack, false);
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
        animator = GetComponentInChildren<Animator>();
    }
}