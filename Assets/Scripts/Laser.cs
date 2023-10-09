using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float dmgLaser;
    [SerializeField] float speedLaser;
    [SerializeField] Rigidbody2D rigitLaser;
    [SerializeField] GameObject explosion;
    public bool isLaserOfPlayer;
    private void Awake()
    {
        rigitLaser = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CheckDestroy();
    }
    private void CheckDestroy()
    {
        if(transform.position.y < -Camera.main.orthographicSize || transform.position.y > Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
    public void LaserMove(Vector3 directionLaser)
    {
        rigitLaser.velocity = directionLaser * speedLaser;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && isLaserOfPlayer)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDmg(dmgLaser);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(!collision.gameObject.CompareTag("Player") && !isLaserOfPlayer)
        {
            
        }else
        {
            collision.gameObject.GetComponent<Player>().TakeDmg(dmgLaser);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        

    }
}
