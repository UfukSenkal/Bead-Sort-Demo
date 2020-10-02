using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    #region Singleton class: Level

    public static Level Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }

    #endregion

  
    public int level=1;
    public int stage;
    public int totalBallCount;



    void Start()
    {
        totalBallCount = 0;

        level = PlayerPrefs.GetInt("Level");

        if (level == 0)
        {
            level = 1;
            PlayerPrefs.SetInt("Level", level);
        }
   
    }


 
}
