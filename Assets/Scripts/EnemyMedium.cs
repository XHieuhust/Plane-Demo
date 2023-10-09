using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMedium : Enemy
{
    protected override void EnemyMove()
    {
        rigitEnemy.velocity = (Vector3.zero - transform.position).normalized * speedEnemy;
    }
}
