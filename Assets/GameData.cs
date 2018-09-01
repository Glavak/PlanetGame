using System;
using UnityEngine;

public class GameData
{
    public static GameData Instance
    {
        get
        {
            if (instance == null) instance = new GameData();
            return instance;
        }
    }

    private static GameData instance;

    private GameData()
    {
    }

    public event Action<int> OnCoinsChanged;

    public int Coins
    {
        get { return PlayerPrefs.GetInt("Coins"); }
        set
        {
            PlayerPrefs.SetInt("Coins", value);
            if (OnCoinsChanged != null) OnCoinsChanged(value);
        }
    }

    public int PlanetSkin
    {
        get { return PlayerPrefs.GetInt("PlanetSkin", 0); }
        set { PlayerPrefs.SetInt("PlanetSkin", value); }
    }

    public event Action<int> OnLevelChanged;

    public int Level
    {
        get { return PlayerPrefs.GetInt("Level", 1); }
        set
        {
            PlayerPrefs.SetInt("Level", value);
            if (OnLevelChanged != null) OnLevelChanged(value);
        }
    }

    public float Expirience { get; set; }

    public int ExpirienceRequiredForLevelUp()
    {
        return Level * 35;
    }
}
