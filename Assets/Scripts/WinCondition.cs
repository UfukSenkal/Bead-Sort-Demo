using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
   
//tüm topların yerinde olduğunu kontrol etme
    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Ball" && (this.GetComponent<MeshRenderer>().material.name == col.gameObject.GetComponent<MeshRenderer>().material.name))
        {
            col.gameObject.GetComponent<BallMovement>().winCond = true;
            Level.Instance.totalBallCount++;
            UIManager.Instance.slider.value++;

            if (Level.Instance.totalBallCount == GameController.Instance.count)
            {
                Game.isGameover = true;
                PlayerPrefs.SetInt("Level", ++Level.Instance.level);
                UIManager.Instance.buttonText.text = "Next Level";
            }


        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Ball" && (this.GetComponent<MeshRenderer>().material.name == col.gameObject.GetComponent<MeshRenderer>().material.name))
        {
            col.gameObject.GetComponent<BallMovement>().winCond = false;
            Level.Instance.totalBallCount--;
            UIManager.Instance.slider.value--;

        }
    }
}
