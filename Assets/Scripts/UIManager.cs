using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager ins;
    [SerializeField] GameplayPanel gameplayPanel;
    [SerializeField] PausePanel pausePanel;
    [SerializeField] HomePanel homePannel;
    [SerializeField] GameOverPanel gameOverPanel;
    [SerializeField] EndRoundPanel endRoundPanel;

    private void Awake()
    {
        ins = this;
    }

    public void SetActiveGamePlayPanel()
    {
        gameplayPanel.gameObject.SetActive(true);
    }

    public void SetActivePausePanel()
    {
        pausePanel.gameObject.SetActive(true);
    }

    public void SetActiveGameOverPanel() { 
        gameOverPanel.gameObject.SetActive(true);
    }

    public void SetActiveEndRoundPanel()
    {
        Time.timeScale = 0;
        Map.ins.isGameRunning = false;
        endRoundPanel.gameObject.SetActive(true);
        endRoundPanel.SetStarEndGame();
    }
}
