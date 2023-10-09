using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] Button btnX;

    private void Awake()
    {
        btnX.onClick.AddListener(delegate
        {
            this.gameObject.SetActive(false);
        });
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
