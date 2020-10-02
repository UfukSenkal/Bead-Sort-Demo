using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Singleton class: GameController
    public static GameController Instance ;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }
    #endregion


    [SerializeField]
    Material[] materials;

    [SerializeField]
    GameObject ball;

    [SerializeField]
    GameObject rightColorObj;

    [SerializeField]
    GameObject leftColorObj;

    [SerializeField]
    GameObject rightGroundObj;

    [SerializeField]
    GameObject leftGroundObj;

    [SerializeField]
    GameObject cylinder;


    public Button buton1;
    public Button buton2;


    Material[] colorCylinderArray;
    Material[] changeMat;

    
    public GameObject spawnerRight;
    public GameObject spawnerLeft;

    Vector3 posRight;
    Vector3 posLeft;
    
    List<GameObject> ballPool;

    int randomColorFirst;
    int randomColorSecond;
    int level;
    int levelDifficulty = 10;

    public int count;
 
    void Start()
    {
        level = PlayerPrefs.GetInt("Level");
        count =  level * levelDifficulty;
        if (count == 0)
        {
            count = 10;
        }
        if (count > 100)
        {
            count = 100;
        }


        posRight = spawnerRight.GetComponent<Transform>().position;
        posLeft = spawnerLeft.GetComponent<Transform>().position;

        RandomColorSelect();

        changeMat = new Material[2];
        colorCylinderArray = cylinder.GetComponent<MeshRenderer>().materials;
        changeMat[1] = materials[randomColorFirst];
        changeMat[0] = colorCylinderArray[0];
        cylinder.GetComponent<MeshRenderer>().materials = changeMat;


        ColorForSelection();

        ballPool = new List<GameObject>();

        BallPoolManager(count);
        StartCoroutine(InstantiateBalls(ballPool));

        Game.isGameover = false;
    }
//topları oluşturma
    void BallPoolManager(int ballCount)
    {
        for (int i = 0; i < ballCount; i++)
        {
            Vector3 spawnPosRight = new Vector3(posRight.x, posRight.y, Random.Range(2.1f, 2.9f));
            Vector3 spawnPosLeft = new Vector3(posLeft.x, posLeft.y, Random.Range(2.1f, 2.9f));

            GameObject go = Instantiate(ball, spawnPosLeft, Quaternion.identity);

            go.GetComponent<MeshRenderer>().material = materials[randomColorSecond];

            if (i % 2 == 0)
            {

                go.transform.position = spawnPosRight;
                go.GetComponent<MeshRenderer>().material = materials[randomColorFirst];
            }
            go.SetActive(false);
            ballPool.Add(go);

        }
    }
    //topları aktif etme
    IEnumerator InstantiateBalls(List<GameObject> pool)
    {
      

        foreach (var item in pool)
        {
            item.SetActive(true);
            yield return new WaitForSeconds(.01f);
        }
       
    }
    //renk seçimi
    void RandomColorSelect()
    {
        randomColorFirst = Random.Range(0, materials.Length);
        randomColorSecond = Random.Range(0, materials.Length);


        if (randomColorFirst == randomColorSecond)
        {
            if (randomColorSecond == 0)
            {
                randomColorSecond++;
            }
            else
            {
                randomColorSecond--;
            }            
            
        }
       
    }
    //buton ve mapteki renkleri yerleştirme
    void ColorForSelection()
    {
        leftColorObj.GetComponent<MeshRenderer>().material = materials[randomColorFirst];
        rightColorObj.GetComponent<MeshRenderer>().material = materials[randomColorSecond];
        leftGroundObj.GetComponent<MeshRenderer>().material = materials[randomColorFirst];
        rightGroundObj.GetComponent<MeshRenderer>().material = materials[randomColorSecond];


        buton1.GetComponent<Image>().material = materials[randomColorFirst];
        buton2.GetComponent<Image>().material = materials[randomColorSecond];
    }
   
    public void ButtonClick()
    {
        if (!Game.isGameover)
        {
            changeMat[1] = buton1.GetComponent<Image>().material;

            cylinder.GetComponent<MeshRenderer>().materials = changeMat;
        }



    }
    public void ButtonClick2()
    {
        if (!Game.isGameover)
        {
            changeMat[1] = buton2.GetComponent<Image>().material;

            cylinder.GetComponent<MeshRenderer>().materials = changeMat;
        }
       
       
    }

    
}
