using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    
   GameObject vacuum;
    Rigidbody rb;  
    Material mat;

    public float speed,distance,force;

    Vector3 spawnPos;
   
   public  bool dontMove,winCond;
   
    void Start()
    {
        
        mat = this.gameObject.GetComponent<MeshRenderer>().material;
        vacuum = GameObject.FindGameObjectWithTag("Magnet");      
        rb = GetComponent<Rigidbody>();

        spawnPos = transform.position;

        dontMove = false;
        winCond = false;
       
    }


    void Update()
    {

        if (dontMove  && !CylinderMovement.Instance.touching)
        {
            
            transform.SetParent(null);
            rb.useGravity = true;
          
        }

    }

    //silindirin içine gönder
    public void MoveToVacuum()
    {
        if (CylinderMovement.Instance.touching)
        {

            rb.AddForce(-Physics.gravity * force);
            rb.useGravity = false;
            transform.SetParent(vacuum.transform);
          
        }
     
    }
    //mapden çıkma ve doğru zemine değdiğinde hareket ettirme
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {

            StartCoroutine(ReturnToMap());
           

        }
        if ((col.gameObject.tag == "LevelColor") && col.gameObject.GetComponent<MeshRenderer>().material.name == mat.name)
        {

                dontMove = true;
             
        }

    }

    //mapten çıkarsa mape geri gönder gecikme ile
    IEnumerator ReturnToMap()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
        transform.position = spawnPos;
        this.gameObject.SetActive(true);
        
    }
   

}
