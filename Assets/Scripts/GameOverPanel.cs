using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Button btnExit;
    [SerializeField] Button btnBackHome;
    private void Awake()
    {
        btnExit.onClick.AddListener(delegate
        {
            Application.Quit();
        });

        btnBackHome.onClick.AddListener(delegate
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }
}
