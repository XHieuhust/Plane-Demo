using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float timeExist;

    private void Start()
    {
        StartCoroutine(StartToDestroy());   
    }

    IEnumerator StartToDestroy()
    {
        yield return new WaitForSeconds(timeExist);
        Destroy(gameObject);
    }
}
