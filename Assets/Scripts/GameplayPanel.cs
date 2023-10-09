using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayPanel : MonoBehaviour
{
    [SerializeField] Button btnPause;
    [SerializeField] TextMeshProUGUI textPoint;

    private void Awake()
    {
        btnPause.onClick.AddListener(delegate
        {
            UIManager.ins.SetActivePausePanel();
        });
    }
    private void Update()
    {
        textPoint.text = SingleTon.ins.point.ToString();
    }
}
