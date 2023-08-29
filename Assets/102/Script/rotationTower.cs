using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(LineRenderer))]
public class rotationTower : MonoBehaviour
{
    #region 
    [Header("TowerMoveInfo")]
    [SerializeField] Transform rotationCenter;
    [SerializeField] float rotationRadius, angularSpeed;
    [SerializeField] private GameObject lazer;
    [SerializeField] private GameObject lazerend;

    float posX, posY, angle = 0f;
    [SerializeField] private float leftLockAngle;
    [SerializeField] private float rightLockAngle;
    [SerializeField] private float rote;
    [SerializeField] private Transform lazerPos;
    [SerializeField] private int raydistance;
    RaycastHit2D lrhit;
    public LineRenderer lr;
    [SerializeField] public LayerMask whatisEnemy;
    [SerializeField] public LayerMask whatisEnd;
    Vector2 pos;
    [SerializeField] float Atk;
    #endregion
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        
    }
    void Update()
    {
        Move();
        SetRotation();
        Attack();


    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.C))
        {
            LrDraw();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            LrDisable();
        }
    }

    void LrDisable()
    {
        lr.enabled = false;
    }
    void LrDraw()
    {
      
        //pos = new Vector2(-transform.position.x, transform.position.y);
        lr.SetPosition(0, lazerPos.position);
        if (lrhit = Physics2D.Raycast(transform.position, transform.up, raydistance, whatisEnd))
        {
            lr.SetPosition(1, lrhit.point);

            lr.enabled = true;
            //Instantiate(lazerend,lrhit.point,Quaternion.identity);
        }
        if (lrhit = Physics2D.Raycast(transform.position, transform.up, raydistance, whatisEnemy))
        {
            lr.SetPosition(1, lrhit.point);

            lr.enabled = true;
           

             
        }
       
     
    }

   
    void SetRotation() 
    {
        if (angle > 1.5 && angle < 1.6)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius / 1.5f;


        transform.position = new Vector3(posX, posY);
    }

    void Move() 
    {
        if (angle < leftLockAngle)
        {
            if (Input.GetKey(KeyCode.Z))
            {

                angle = angle + Time.deltaTime * angularSpeed;
                transform.Rotate(0, 0, rote);
                if (angle >= leftLockAngle)
                {

                    transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }
        }

        if (angle > rightLockAngle)
        {
            if (Input.GetKey(KeyCode.X))
            {

                angle = angle + Time.deltaTime * -angularSpeed;
                transform.Rotate(0, 0, -rote);
                if (angle <= rightLockAngle)
                {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                }
            }
        }

    }
}
