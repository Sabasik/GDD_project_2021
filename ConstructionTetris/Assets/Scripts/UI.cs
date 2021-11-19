using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class UI : MonoBehaviour
{
    public Button NewGame;
    public Button Quit;
    public TextMeshProUGUI Message;
    public static string mess = "";

    public TextMeshProUGUI LivesOptionText;
    public TextMeshProUGUI TimeOptionText;
    public TextMeshProUGUI DifficultyOptionText;

    private void Awake()
    {
        //Events.GameEndMessage += UpdateMessage;
    }

    private void UpdateMessage(string mess)
    {
        Message.text = mess;
    }

    private void OnDestroy()
    {
        //Events.GameEndMessage -= UpdateMessage;
    }

    void Start()
    {
        Message.text = mess;
    }

    void Update()
    {
        Message.text = mess;
    }

    public void DecreaseTime()
    {
        TimeOptionText.text = Events.ChangeTime(false);
    }

    public void DecreaseLives()
    {
        LivesOptionText.text = Events.ChangeLives(false);
    }

    public void DecreaseDifficulty()
    {
        DifficultyOptionText.text = Events.ChangeDifficulty(false);
    }

    public void IncreaseTime()
    {
        TimeOptionText.text = Events.ChangeTime(true);
    }

    public void IncreaseLives()
    {
        LivesOptionText.text = Events.ChangeLives(true);
    }

    public void IncreaseDifficulty()
    {
        DifficultyOptionText.text = Events.ChangeDifficulty(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void ThemesMenu()
    {
        SceneManager.LoadScene("ThemesMenu");
    }

    public void InfoMenu()
    {
        SceneManager.LoadScene("InfoMenu");
    }
}
