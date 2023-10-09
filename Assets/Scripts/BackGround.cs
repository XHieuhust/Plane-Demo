using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] float BackGroundSpeed;
    private void Update()
    {
        BackGroundMove();
        ResetBackGround();
    }
    private void BackGroundMove()
    {
        transform.position += Vector3.down * BackGroundSpeed * Time.deltaTime;
    }

    private void ResetBackGround()
    {
        if (transform.position.y <= -2 * Camera.main.orthographicSize)
        {
            transform.position = new Vector3(transform.position.x, 2 * 2 * Camera.main.orthographicSize);
        }
    }
}
