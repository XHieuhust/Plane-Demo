using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITakeDmg, IFire
{
    [SerializeField] protected float MaxHp;
    protected float hp;
    [SerializeField] protected float speedEnemy;
    protected Rigidbody2D rigitEnemy;
    [SerializeField] protected float timeFire;
    [SerializeField] protected GameObject LaserEnemy;
    [SerializeField] protected Transform pointGun;
    [SerializeField] BarHp barHP;

    public void Start()
    {
        hp = MaxHp;
        rigitEnemy = GetComponent<Rigidbody2D>();
        EnemyMove();
        Fire();
    }
    public void CheckDie()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
            SingleTon.ins.point++;
        }
    }

    virtual protected void EnemyMove()
    {

    }

    public void TakeDmg(float laserDmg)
    {
        hp -= laserDmg;
        barHP.SetRatio(hp / MaxHp);
        CheckDie();
    }

    public void Fire()
    {
        StartCoroutine(StartFireToPlayer());
    }

    IEnumerator StartFireToPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeFire);
            if (transform.position.y <= Camera.main.orthographicSize)
            {
                GameObject laserSpawn = Instantiate(LaserEnemy, pointGun.position, Quaternion.identity);
                laserSpawn.GetComponent<Laser>().LaserMove(-transform.up);
            }
        }
    }
}
