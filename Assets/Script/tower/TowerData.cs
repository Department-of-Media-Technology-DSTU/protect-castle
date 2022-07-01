using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]  // this allows us to quickly change all values ​​of the Level class, even when the game is running
public class TowerLevel
{
    public Sprite img;
    public string strength;
    public string rateOfFire;
    public string attackRadius;
    public int cost;
    public int refundAmount;
    public GameObject bullet;
    public float fireRate;
    public GameObject visualization;
}

public class TowerData : MonoBehaviour
{
    private TowerLevel currentLevel;
    public List<TowerLevel> levels;
    public string Name;
    public Sprite icon;

    public TowerLevel CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            GameObject levelVisualization = levels[currentLevelIndex].visualization;
            for (int i = 0; i < levels.Count; i++)
            {
                if (levelVisualization != null)
                {
                    if (i == currentLevelIndex)
                    {
                        levels[i].visualization.SetActive(true);
                    }
                    else
                    {
                        levels[i].visualization.SetActive(false);
                    }
                }
            }
        }
    }

    void OnEnable()
    {
        CurrentLevel = levels[0];
    }

    public TowerLevel GetNextLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLevelIndex = levels.Count - 1;

        if (currentLevelIndex < maxLevelIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }

    public void IncreaseLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        
        if (currentLevelIndex < levels.Count - 1)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }
}
