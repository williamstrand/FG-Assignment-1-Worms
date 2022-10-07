using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _winnerText;

    void Start()
    {
        var winner = (GameController.Team)PlayerPrefs.GetInt("Winner");

        SetWinnerText(winner);
    }

    /// <summary>
    /// Set the winner text to the winner of the game.
    /// </summary>
    /// <param name="winningTeam">the team that won.</param>
    void SetWinnerText(GameController.Team winningTeam)
    {
        if(winningTeam == GameController.Team.NoTeam)
        {
            _winnerText.text = "TIE!";
        }
        else
        {
            _winnerText.text = $"Team {((int)winningTeam) + 1} has won!";
        }
    }

    /// <summary>
    /// Changes scene to main menu.
    /// </summary>
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
