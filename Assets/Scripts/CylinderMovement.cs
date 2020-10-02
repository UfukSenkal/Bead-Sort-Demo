using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    private Touch touch;
    private float speedForPc, x, y,speedForMobile;
    public bool touching;
    Vector3 targetPos;

    #region Singleton class: CylinderMovement

    public static CylinderMovement Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }
    #endregion

    void Start()
    {
        speedForPc = 0.2f;
        speedForMobile = 0.005f;
    }

   //hareket kodları
    void Update()
    {


#if UNITY_EDITOR

        if (!Game.isGameover && Input.GetMouseButton(0))
        {
            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");
            targetPos = new Vector3(
                    transform.position.x + x * speedForPc,
                    transform.position.y,
                    transform.position.z + y * speedForPc);
           
            if (targetPos.x > -.4f && targetPos.x < .7f && targetPos.z < 4 && targetPos.z > 1.4f)
            {
                transform.position = targetPos;
            }
            
            touching = true;
            
        }
        if (!Input.GetMouseButton(0))
        {
             touching = false;
            
            
        }

#else
        if (!Game.isGameover && Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        
            if (touch.phase == TouchPhase.Moved)
            {
                targetPos = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedForMobile,
                    transform.position.y,
                    transform.position.z + touch.deltaPosition.y * speedForMobile);
          if (targetPos.x > -.4f && targetPos.x < .7f && targetPos.z < 4 && targetPos.z > 1.4f)
            {
                transform.position = targetPos;
            }
        touching = true;
            }
        }
         if (Input.touchCount <= 0)
        {
             touching = false;
            
            
        }
       
   
#endif
    }
}
