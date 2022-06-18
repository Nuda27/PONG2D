using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;

    [Header("Main Menu Panel List")]
    public GameObject MainPanel;
    public GameObject HowtoPlayPanel;
    public GameObject TimerPanel;
    public GameObject SelectBallPanel;
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        HowtoPlayPanel.SetActive(false);
        SelectBallPanel.SetActive(false);
        TimerPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SinglePlayerButton()
    {
        GameData.instance.isSinglePlayer = true;
        TimerPanel.SetActive(true);
        MainPanel.SetActive(false);
        SoundManager.instance.UIClickSfx();
    }

    public void MultiPlayerButton()
    {
        GameData.instance.isSinglePlayer = false;
        TimerPanel.SetActive(true);
        MainPanel.SetActive(false);
        SoundManager.instance.UIClickSfx();
    }

    public void BackButton()
    {
        HowtoPlayPanel.SetActive(false);
        TimerPanel.SetActive(false);
        SelectBallPanel.SetActive(false);
        MainPanel.SetActive(true);
        SoundManager.instance.UIClickSfx();
    }

    public void SetTimerButton(float Timer)
    {
        GameData.instance.gameTimer = Timer;
        //HowtoPlayPanel.SetActive(true);
        //MainPanel.SetActive(false);
        //TimerPanel.SetActive(false);
        SelectBallPanel.SetActive(true);
        SoundManager.instance.UIClickSfx();
    }

    public void SelectBall(GameObject ball)
    {
        GameData.instance.selectBall = ball;
        HowtoPlayPanel.SetActive(true);
        MainPanel.SetActive(false);
        //TimerPanel.SetActive(false);
        SelectBallPanel.SetActive(false);
        SoundManager.instance.UIClickSfx();
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("2. GamePlay");
    }

    public void MuteBtn()
    {
        //audio.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
