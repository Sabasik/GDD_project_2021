using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ThemesUI : MonoBehaviour
{
    public Button originalTheme;
    public Button darkTheme;
    public Button specialTheme;

    public TextMeshProUGUI originalThemeText;
    public TextMeshProUGUI darkThemeText;
    public TextMeshProUGUI specialThemeText;

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

    public void ChangeThemeOriginal()
    {
        Events.ChangeThemeOriginal(true);
    }

    public void ChangeThemeDark()
    {
        Events.ChangeThemeDark(true);
    }

    public void ChangeThemeSpecial()
    {
        Events.ChangeThemeSpecial(true);
    }
}
