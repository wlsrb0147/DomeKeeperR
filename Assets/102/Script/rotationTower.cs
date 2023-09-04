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
[RequireComponent(typeof(EdgeCollider2D))]
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
    EdgeCollider2D edgeCollider2d;
    [SerializeField] public LayerMask whatisEnemy;
    [SerializeField] public LayerMask whatisEnd;
    Vector2 pos;
    [SerializeField] float Atk;
    #endregion
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        edgeCollider2d = GetComponent<EdgeCollider2D>();
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
        Vector3 tempFp = lazerPos.transform.position;
        if (Vector2.Distance(tempFp, fingerPositions[fingerPositions.Count - 1]) > .1f)
        {
            UpdateLine(tempFp);
        }

        currentLine = Instantiate(linePrefab, Vector3.zero,Quaternion.identity);
        lr = currentLine.GetComponent<LineRenderer>();
        edgeCollider2d = currentLine.GetComponent<EdgeCollider2D>(); 
        
        Vector3 line_startPos = lazerPos.transform.position;
        fingerPositions.Add(line_startPos); 


        edgeCollider2d.points = fingerPositions.toArray();

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
