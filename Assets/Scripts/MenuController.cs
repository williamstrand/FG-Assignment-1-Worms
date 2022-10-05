using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    [SerializeField] GameObject _teamSetup;
    [SerializeField] TextMeshProUGUI _teamsText;
    [SerializeField] TextMeshProUGUI _charactersText;
    [SerializeField] Slider _teamsSlider;
    [SerializeField] Slider _charactersSlider;

    void Start()
    {
        _menu.SetActive(true);
        _teamSetup.SetActive(false);
        UpdateCharactersText();
        UpdateTeamsText();
    }

    public void StartGameButton()
    {
        _menu.SetActive(false);
        _teamSetup.SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("Teams", (int)_teamsSlider.value);
        PlayerPrefs.SetInt("Characters", (int)_charactersSlider.value);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void UpdateTeamsText()
    {
        _teamsText.text = $"{_teamsSlider.value} teams";
    }

    public void UpdateCharactersText()
    {
        _charactersText.text = (_charactersSlider.value > 1) ? $"{_charactersSlider.value} characters per team" : $"{_charactersSlider.value} character per team";
    }

    public void Exit()
    {
        Application.Quit();
    }
}
