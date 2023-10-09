using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndRoundPanel : MonoBehaviour
{
    [SerializeField] Image goldStar;
    [SerializeField] Image Star1;
    [SerializeField] Image Star2;
    [SerializeField] Image Star3;
    [SerializeField] Button btnBackHome;
    [SerializeField] Button btnShare;

    private void Awake()
    {     
        btnBackHome.onClick.AddListener(delegate
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        btnShare.onClick.AddListener(delegate
        {
            ScreenCapture.CaptureScreenshot("achivement.png");
        });
    }

    public void SetStarEndGame()
    {
        if(SingleTon.ins.point >= Map.ins.numberEnemy/3)
        {
            Star1.GetComponent<Image>().sprite = goldStar.GetComponent<Image>().sprite;
        }

        if(SingleTon.ins.point >= 3 * Map.ins.numberEnemy / 5)
        {
            Star2.GetComponent<Image>().sprite = goldStar.GetComponent<Image>().sprite;
        }

        if(SingleTon.ins.point >= 4 * Map.ins.numberEnemy / 5)
        {
            Star3.GetComponent<Image>().sprite = goldStar.GetComponent<Image>().sprite;
        }
    }
}
