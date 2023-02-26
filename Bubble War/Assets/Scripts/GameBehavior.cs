using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour, IManager

{
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    private int _itemsCollected = 0;
    public Stack<string> lootStack = new Stack<string>();
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    public int Items

    {

        get { return _itemsCollected; }

        set
        {
            _itemsCollected = value;
            if (_itemsCollected >= maxItems)
            {
                showWinScreen = true;
                labelText = "You’ve found all the items!";

                Time.timeScale = 0f;
            }
            else
            {
                labelText = $"Item found, only {maxItems - _itemsCollected} more to go!";
            }
        }
    }
    private int _playerHP = 3;

    public int HP
    {

        get { return _playerHP; }
        set
        {
            if (_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0f;
            }
            {
                labelText = "Ouch... that’s got hurt.";
            }
            _playerHP = value;
            Debug.LogFormat($"Lives: {_playerHP}");
        }
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        _state = "Manager initialized..";
        Debug.Log(_state);

        lootStack.Push("Sword of Doom");
        lootStack.Push("HP+");
        lootStack.Push("Golden Key");
        lootStack.Push("Winged Boot");
        lootStack.Push("Mythril Bracers");
    }

    void OnGUI()
    {

        GUI.Box(new Rect(20, 20, 150, 25), $"Player Health: {_playerHP}");

        GUI.Box(new Rect(20, 50, 150, 25), $"Items Collected: {_itemsCollected}");

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))

            {
                Utilities.RestartLevel(0);
            }
        }
        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                Utilities.RestartLevel(0);
            }
        }

    }
    public void PrintLootReport()
       {
        var currentItem = lootStack.Pop();

        var nextItem = lootStack.Peek();
    
            Debug.LogFormat($"You got a {currentItem}! You’ve got a good chance of findinga {nextItem} next!");
    
            Debug.LogFormat($"There are {lootStack.Count} random loot items waiting for you!");
        }
   
}

