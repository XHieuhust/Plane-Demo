using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map : MonoBehaviour
{
    [SerializeField] GameObject enemySmall;
    [SerializeField] GameObject enemyMedium;
    [SerializeField] GameObject enemyBig;
    [SerializeField] int numberEnemyBig;
    [SerializeField] int numberEnemySmall;
    [SerializeField] int numberEnemyMedium;
    public int numberEnemy;
    public bool isGameRunning;
    public static Map ins;
    private void Awake()
    {
        ins = this;
    }

    public void StartGameLevel1()
    {
        isGameRunning = true;
        numberEnemy = numberEnemySmall;
        StartCoroutine(SpawnEnemyLevel1());
    }
    public void StartGameLevel2()
    {
        isGameRunning = true;
        numberEnemy = numberEnemyMedium;
        StartCoroutine(SpawnEnemyLevel2());
    }

    public void StartGameLevel3()
    {
        isGameRunning = true;
        numberEnemy = numberEnemyBig;
        StartCoroutine(SpawnEnemyLevel3());
    }

    IEnumerator SpawnEnemyLevel1()
    {
        while (numberEnemySmall > 0)
        {
            yield return new WaitForSeconds(2);
            Instantiate(enemySmall,
                new Vector3(Random.Range(-Camera.main.orthographicSize / Screen.height * Screen.width, Camera.main.orthographicSize / Screen.height * Screen.width), Camera.main.orthographicSize + 2, 0),
                Quaternion.identity);
            numberEnemySmall--;
        }
        yield return new WaitForSeconds(6);
        EndGame();
    }

    IEnumerator SpawnEnemyLevel2()
    {
        while (numberEnemyMedium > 0)
        {
            yield return new WaitForSeconds(2);
            Instantiate(enemyMedium,
                new Vector3((Random.Range(0, 2) == 0) ? -Camera.main.orthographicSize / Screen.height * Screen.width : Camera.main.orthographicSize / Screen.height * Screen.width,
                Camera.main.orthographicSize + 1, 0),
                Quaternion.identity);
            numberEnemyMedium--;
        }
        yield return new WaitForSeconds(6);
        EndGame();
    }

    IEnumerator SpawnEnemyLevel3()
    {
        while (numberEnemyBig > 0)
        {
            yield return new WaitForSeconds(3);
            Instantiate(enemyBig,
                new Vector3((Random.Range(0, 2) == 0) ? -Camera.main.orthographicSize / Screen.height * Screen.width - 1 : Camera.main.orthographicSize / Screen.height * Screen.width + 1,
                Random.Range(Camera.main.orthographicSize / 4, 3 / 4 * Camera.main.orthographicSize), 0),
                Quaternion.identity);
            numberEnemyBig--;
        }
        yield return new WaitForSeconds(6);
        EndGame();
    }

    public void EndGame()
    {
        UIManager.ins.SetActiveEndRoundPanel();
    }

}

