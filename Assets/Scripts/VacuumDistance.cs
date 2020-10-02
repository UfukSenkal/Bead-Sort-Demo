using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumDistance : MonoBehaviour
{
    [SerializeField] GameObject go;
    Vector2 posBall, posCylinder;
    //silindire olan uzaklığa göre topları çekme
void OnTriggerEnter(Collider col)
    {
       
        if (col.tag == "Ball" && (go.GetComponent<MeshRenderer>().materials[1].name == col.gameObject.GetComponent<MeshRenderer>().material.name))
        {
            posBall = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.z);
            posCylinder = new Vector2(transform.position.x, transform.position.z);
           
            if (!col.gameObject.GetComponent<BallMovement>().winCond && Vector2.Distance(posBall,posCylinder) < .1f )
            {
                col.gameObject.GetComponent<BallMovement>().MoveToVacuum();

            }
            
           
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Ball" && (go.GetComponent<MeshRenderer>().materials[1].name == col.gameObject.GetComponent<MeshRenderer>().material.name))
        {
            col.gameObject.GetComponent<BallMovement>().dontMove = true;
            
            
        }
    }
}
