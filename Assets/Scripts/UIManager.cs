using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton class: UIManager

    public static UIManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }

    #endregion

    [SerializeField] Text levelText;
    [SerializeField] Text nextLevelText;
    [SerializeField] Button button;


    public Slider slider;


    int level, nextLevel;
    public Text buttonText;
   

    void Start()
    {
       

        button.gameObject.SetActive(false);
        level = PlayerPrefs.GetInt("Level");
        levelText.text = level.ToString();
        nextLevel = level + 1;
        nextLevelText.text = nextLevel.ToString();
        slider.maxValue = GameController.Instance.count;


    }

   
    void Update()
    {
        if (Game.isGameover)
        {
            button.gameObject.SetActive(true);
        }
    }

    
    public void LevelUp()
    {

        SceneManager.LoadScene(0);
    }
   
}
