using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBig : Enemy
{
    protected override void EnemyMove()
    {
        StartCoroutine(StartToMove());
    }

    IEnumerator StartToMove()
    {
        float randomeX;
        while (true)
        {
            randomeX = Random.Range(-Camera.main.orthographicSize / Screen.height * Screen.width, Camera.main.orthographicSize / Screen.height * Screen.width);
            rigitEnemy.velocity = (new Vector3(randomeX, transform.position.y, 0) - transform.position).normalized * speedEnemy;
            yield return new WaitForSeconds(1.5f);
        }
    }
}
