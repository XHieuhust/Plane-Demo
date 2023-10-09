using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDmg, IFire
{
    [SerializeField] float MaxHp;
    [SerializeField] float speed;
    private Vector3 cachePos;
    [SerializeField] GameObject laser;
    [SerializeField] Transform pointGun;
    [SerializeField] float hpPlayer;
    [SerializeField] BarHp barHP;
    // Update is called once per frame
    private void Start()
    {
        hpPlayer = MaxHp;   
    }
    private void Update()
    {
        Move();
        CheckOutScreen();
        Fire();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0) && Map.ins.isGameRunning)
        {
            Vector3 direction = Input.mousePosition - cachePos;
            transform.position += direction.normalized * speed;
            cachePos = Input.mousePosition;
        }
    }

    private void CheckOutScreen()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, - Camera.main.orthographicSize / Screen.height * Screen.width, Camera.main.orthographicSize / Screen.height * Screen.width)
                            , Mathf.Clamp(transform.position.y, - Camera.main.orthographicSize, Camera.main.orthographicSize), transform.position.z);
    }

    private void CheckDie()
    {
        if(hpPlayer <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            UIManager.ins.SetActiveGameOverPanel();
        }
    }
    public void TakeDmg(float laserDmg)
    {
        hpPlayer -= laserDmg;
        CheckDie();
        barHP.SetRatio(hpPlayer / MaxHp);
    }

    public void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Map.ins.isGameRunning)
        {
            GameObject laserSpawn = Instantiate(laser, pointGun.transform.position, Quaternion.identity);
            laserSpawn.GetComponent<Laser>().LaserMove(transform.up);
            laserSpawn.GetComponent<Laser>().isLaserOfPlayer = true;
        }
    }
}
