using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Toggle sound;
    public Button instructions;

    private void Start()
    {
        sound.isOn = Events.soundOn;
    }

    public void ToggleSound()
    {
        Events.soundOn = sound.isOn;
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
    public void OpenInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
