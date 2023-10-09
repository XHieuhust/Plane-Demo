using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : MonoBehaviour
{
    [SerializeField] Button btnLevel1;
    [SerializeField] Button btnLevel2;
    [SerializeField] Button btnLevel3;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Awake()
    {
        btnLevel1.onClick.AddListener(delegate
        {
            OnClickButton();
            Map.ins.StartGameLevel1();
        });
        btnLevel2.onClick.AddListener(delegate
        {
            OnClickButton();
            Map.ins.StartGameLevel2();
        });
        btnLevel3.onClick.AddListener(delegate
        {
            OnClickButton();
            Map.ins.StartGameLevel3();
        });
    }

    void OnClickButton()
    {
        UIManager.ins.SetActiveGamePlayPanel();
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
