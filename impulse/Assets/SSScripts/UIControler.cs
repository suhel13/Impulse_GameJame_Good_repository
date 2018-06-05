using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIControler : MonoBehaviour
{
    public ExitZone exitZone;
    public PlayerControler playerCon;

    public GameObject wonPanel;
    public Text textWin;

    public GameObject losePanel;
    public Text textLose;
    public GameObject menuPanel;
    public GameObject storyPanel;
    public void activeWonPanel()
    {
        wonPanel.SetActive(true);
        textWin.text = ("Zajęło ci to: " + (int)(200 - playerCon.timer) + " sekundy");
    }

    public void activeLosePanel()
    {
        losePanel.SetActive(true);
        if (exitZone.nextSpot==0)
        {
            textLose.text = ("Nie uratowałeś nikogo!!!");
        }
        else if (exitZone.nextSpot<3)
        {
        textLose.text = ("Udało ci się uratować tylko " + exitZone.nextSpot +"!");
        }
    }


    public void moveToStory()
    {
        menuPanel.SetActive(false);
        storyPanel.SetActive(true);
    }

    public void moveToMainManu()
    {
        menuPanel.SetActive(true);
        storyPanel.SetActive(false);
        wonPanel.SetActive(false);
        losePanel.SetActive(false);
    }


    public void startGame()
    {
        storyPanel.SetActive(false);
        Time.timeScale = 1;

    }
    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
