using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIControler : MonoBehaviour
{
    public ExitZone exitZone;
    public PlayerControler playerCon;
    public ScenTransition scenTran;
    public GameObject wonPanel;
    public Text textWin;

    public GameObject losePanel;
    public Text textLose;
    public GameObject menuPanel;
    public GameObject storyPanel;
    public GameObject creditsPanel;

    public Image toSave;
    public Image Saved;

    public GameObject gameAudio;
    public void activeWonPanel()
    {
        wonPanel.SetActive(true);
        textWin.text = ("Zajęło ci to: " + (int)(200 - playerCon.timer) + " sek.");
        Time.timeScale = 0;
        gameAudio.SetActive(false);
    }

    public void activeLosePanel()
    {
        losePanel.SetActive(true);
        if (exitZone.nextSpot == 0)
        {
            textLose.text = ("Nie uratowałeś nikogo!!!");
        }
        else if (exitZone.nextSpot < 3)
        {
            textLose.text = ("Udało ci się uratować tylko " + exitZone.nextSpot + "!");
        }
        Time.timeScale = 0;
        gameAudio.SetActive(false);
    }


    public void moveToStory()
    {
        menuPanel.SetActive(false);
        storyPanel.SetActive(true);
    }

    public void moveToMainManu()
    {
        scenTran.loadScene(0);
    }

    public void moveToCredits()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void moveToMainManuFromCredits()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }


    public void startGame(int level)
    {
        scenTran.loadScene(level);
    }
    public void restartGame(int level)
    {
        scenTran.loadScene(level);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void updatePeople()
    {
        Saved.fillAmount = exitZone.nextSpot / 3f;
        toSave.fillAmount = (3 - exitZone.nextSpot) / 3f;
    }


}
