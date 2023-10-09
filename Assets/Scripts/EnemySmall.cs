using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : Enemy
{
    protected override void EnemyMove()
    {
        rigitEnemy.velocity = -transform.up * speedEnemy;
    }

}
