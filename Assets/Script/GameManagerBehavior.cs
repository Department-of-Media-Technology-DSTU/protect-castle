using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    public Text goldLabel;  // reference to the Text component used to display the amount of gold the player has
    public Text waveLabel; // stores a reference to the wave number output label
    public bool gameOver = false;

    public GameObject gameOverObject;

    public Text healthLabel;

    private int gold;

    public int Gold

    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = gold.ToString();
        }
    }

    private int wave = 0;
    public void Wave()
    {
        /*get
        {
            return wave;
        }
        set
        {
            wave = value;
            waveLabel.text = (wave + 1).ToString();
        }*/
        wave++;
        waveLabel.text = ("ÂÎËÍÀ: " + wave).ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        Gold = 600;
        
        health = 20;
    }
    private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            
            health = value;
            healthLabel.text = health.ToString();
            // 3
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                Time.timeScale = 0f;
                gameOverObject.SetActive(true);
                /*GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                gameOverText.GetComponent<Animator>().SetBool("gameOver", true);*/
            }
            
          
            
        }
    }
}
