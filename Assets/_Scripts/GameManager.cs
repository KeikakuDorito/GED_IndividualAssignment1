using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int maxHealth = 3;
    int healthPoints;

    void Awake()
    {
        healthPoints = maxHealth;
        if (instance == null)
        {
            instance = this;
        }
    }

    public int getHealth()
    {
        return healthPoints;
    }

    public void GainHealth(int healthGain)
    {
        
        healthPoints = healthPoints + healthGain;
        Debug.Log("Heath:" + healthPoints);
    }

    public void TakeDamage()
    {
        Debug.Log("preforming damage");
        if (healthPoints != 0)
        {
            healthPoints--;
            Debug.Log("Heath:" + healthPoints);
        }

        if (healthPoints == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Game Over.");
        }
    }


}
