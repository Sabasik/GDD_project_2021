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

    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
