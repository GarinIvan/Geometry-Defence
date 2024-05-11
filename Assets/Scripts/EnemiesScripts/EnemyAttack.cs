using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyController _enemyController;
    public void Attack()
    {
        _enemyController.AttackBuilding();
    }
}
