using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public static UnityEvent<Character> OnChangeFocus = new UnityEvent<Character>();
    public static UnityEvent<Character> OnActiveCharacterChange = new UnityEvent<Character>();

    public enum Team
    {
        NoTeam = -1,
        Team1,
        Team2,
        Team3,
        Team4
    }

    public struct Game
    {
        public int WormsPerTeam;
        public int Teams;

        public int WormsLeft;

        public Game(int teams, int wormsPerTeam)
        {
            WormsPerTeam = wormsPerTeam;
            Teams = teams;
            WormsLeft = wormsPerTeam * teams;
        }
    }

    public Game CurrentGame;

    Controls _debugControls;

    [SerializeField] Character _characterPrefab;
    [SerializeField] GameObject[] _teamOutfitPrefabs;
    Character[,] _teams;
    [SerializeField] Transform[] _spawnPoints;

    public Team CurrentTeam;
    public int CurrentCharacterIndex;
    Character CurrentCharacter => _teams[(int)CurrentTeam, CurrentCharacterIndex];
    Character _currentFocus;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        _debugControls = new Controls();
        _debugControls.Game.Debug.performed += _ => DebugTest();
        _debugControls.Enable();
    }

    void Start()
    {
        InitGame();
    }

    void OnEnable()
    {
        Character.OnDeath.AddListener(OnDeath);
    }

    void OnDisable()
    {
        Character.OnDeath.RemoveListener(OnDeath);
    }

    /// <summary>
    /// Debug method.
    /// </summary>
    void DebugTest()
    {

    }

    /// <summary>
    /// Initializes the game
    /// </summary>
    void InitGame()
    {
        var teams = PlayerPrefs.GetInt("Teams");
        var characters = PlayerPrefs.GetInt("Characters");
        _teams = CreateNewTeams(teams, characters);
        CurrentGame = new Game(teams, characters);
        CurrentTeam = Team.Team1;
        CurrentCharacterIndex = 0;
        SetActiveCharacter(CurrentCharacter);
    }

    /// <summary>
    /// Creates new teams.
    /// </summary>
    /// <param name="teamCount">the amount of teams.</param>
    /// <param name="wormsPerTeam">the amount of worms per team.</param>
    /// <returns></returns>
    Character[,] CreateNewTeams(int teamCount, int wormsPerTeam)
    {
        var teams = new Character[teamCount, wormsPerTeam];
        for (int i = 0; i < teamCount; i++)
        {
            for (int j = 0; j < wormsPerTeam; j++)
            {
                var spawnPosition = _spawnPoints[i].transform.GetChild(j);
                var newCharacter = Instantiate(_characterPrefab, spawnPosition.position, spawnPosition.rotation);
                Instantiate(_teamOutfitPrefabs[i], newCharacter.transform.position, newCharacter.transform.rotation, newCharacter.transform);
                newCharacter.Team = (Team)i;
                newCharacter.name = $"Team: {i + 1}, Player: {j + 1}";
                newCharacter.SetInactive();
                teams[i, j] = newCharacter;
            }
        }

        return teams;
    }

    /// <summary>
    /// Changes active character to the next.
    /// </summary>
    public void NextCharacter()
    {
        CurrentCharacter.SetInactive();

        if(CurrentCharacterIndex >= CurrentGame.WormsPerTeam - 1)
        {
            CurrentCharacterIndex = 0;
            CurrentTeam = (Team)(((int)CurrentTeam + 1) % CurrentGame.Teams);
        }
        else
        {
            CurrentCharacterIndex += 1;
        }

        if(CurrentCharacter.IsDead)
        {
            NextCharacter();
        } 
        else
        {
            SetActiveCharacter(CurrentCharacter);
        } 
    }

    /// <summary>
    /// Sets the active character to another.
    /// </summary>
    /// <param name="character">the character to change to.</param>
    void SetActiveCharacter(Character character)
    {
        
        CurrentCharacter.SetActive();
        SetFocus(character);
        OnActiveCharacterChange?.Invoke(character);
    }

    /// <summary>
    /// Sets the camera focus to a character.
    /// </summary>
    /// <param name="character">the character to focus.</param>
    void SetFocus(Character character)
    {
        if(_currentFocus != null)
        {
            _currentFocus.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>().Priority = 0;
        }
        _currentFocus = character;
        _currentFocus.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>().Priority = 10;
        OnChangeFocus?.Invoke(character);
    }

    /// <summary>
    /// When a character dies.
    /// </summary>
    /// <param name="character">the character that has died.</param>
    void OnDeath(Character character)
    {
        if(CheckForGameOver()) return;

        if(character == _teams[(int)CurrentTeam, CurrentCharacterIndex]) NextCharacter();
    }

    /// <summary>
    /// Checks if game is over.
    /// </summary>
    /// <param name="teamLeft">the team that is left.</param>
    /// <returns></returns>
    bool CheckForGameOver()
    {
        var teamLeft = Team.NoTeam;
        var teamsLeft = CurrentGame.Teams;
        for (int i = 0; i < CurrentGame.Teams; i++)
        {
            var team = new List<bool>();
            for (int j = 0; j < CurrentGame.WormsPerTeam; j++)
            {
                team.Add(_teams[i, j].IsDead);
            }

            if(!team.Contains(false))
            {
                teamsLeft -= 1;
            } 
            else
            {
                teamLeft = (Team)i;
            }
        }

        if(teamsLeft <= 1)
        {
            EndGame(teamLeft);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Ends the game.
    /// </summary>
    /// <param name="winner">the winner of the match.</param>
    void EndGame(Team winner)
    {
        Time.timeScale = 0;
        if(winner == Team.NoTeam)
        {
            Debug.Log("Tie");
        }
        else
        {
            Debug.Log($"Game Over. {winner + 1} has won!");
        }
    }
}
