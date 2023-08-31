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
public class DefalutTower : MonoBehaviour
{
    #region 
    [Header("타워 움직임")]
    [SerializeField] Transform rotationCenter;
    [SerializeField] float rotationRadius, angularSpeed;
    [SerializeField] private float leftLockAngle;
    [SerializeField] private float rightLockAngle;
    [SerializeField] private float rote;
    float posX, posY, angle = 0f;
    #endregion

    #region 
    [Header("레이저")]
    [SerializeField] private GameObject lazer;
    [SerializeField] private GameObject lazerend;
    [SerializeField] private GameObject BigLazer;
    [SerializeField] private Transform lazerPos;
    [SerializeField] private int raydistance;
    [SerializeField] private float AttackDelayTime;
    [SerializeField] private float chargeTime;
    [SerializeField] private float upgradeChargeTime;
    [SerializeField] private float bigValue;
    [SerializeField] private bool isBigLazer;


    #endregion

    #region 
    [Header("레이캐스트")]
    RaycastHit2D lrhit;
    RaycastHit2D[] lrhits;
    public LineRenderer lr;
    [SerializeField] public LayerMask whatisEnemy;
    [SerializeField] public LayerMask whatisEnd;
    Vector2 pos;
    public bool hitEnemy;
    public float rayDistance = 200f;
    #endregion

    #region 
    [Header("애니메이션")]
    [SerializeField] private GameObject animationPrefab;
    private GameObject currentAnimation; // 현재 재생 중인 애니메이션 프리팹
    #endregion

    [SerializeField] float Atk;

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
        TimeContinue();


    }
    void TimeContinue()
    {
        AttackDelayTime = Time.time;
    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.C))
        {
            LrDraw();
            BigLazerShotReady();


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

    void BigLazerShotReady()
    {
        bigValue += 0.0005f;

        if (bigValue >= 1)
        {
            isBigLazer = true;
            BigLazerCreate();
        }
    }
    void BigLazerCreate()
    {
        GameObject Big = Instantiate(BigLazer, lazerPos.transform.position, lazerPos.transform.rotation);
        
        Destroy(Big, 2);
        Invoke("BigLazerfalse", 2f);
      
        bigValue = 0f;
    }
    void BigLazerfalse()
    {
         isBigLazer = false;
    }
    void LrDraw()
    {
      
        //pos = new Vector2(-transform.position.x, transform.position.y);
        lr.SetPosition(0, lazerPos.position);
        if (lrhit = Physics2D.Raycast(transform.position, transform.up, raydistance, whatisEnd))
        {
            lr.SetPosition(1, lrhit.point);

        
            if (lrhit.collider.CompareTag("Monster"))
            {
                GameObject hitObject = lrhit.collider.gameObject;
             
                    hitObject.GetComponent<M_Base>().Damage(Atk);
                
                
                hitEnemy = true; 
            }
        }

       
        if (!hitEnemy)
        {
            lrhits = Physics2D.RaycastAll(transform.position, transform.up, raydistance, whatisEnemy);

            foreach (RaycastHit2D hit in lrhits)
            {
                if (hit.collider.CompareTag("Monster"))
                {
                    GameObject hitObject = hit.collider.gameObject;
                
                        hitObject.GetComponent<M_Base>().Damage(Atk);
                
                  
                    lr.SetPosition(1, hit.point);
                    lr.enabled = true;

                    Instantiate(lazerend, hit.point, Quaternion.identity);

                    break; //이것만 지우면 관통형 레이저 가능 
                }
            }
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
        if(isBigLazer != true) 
        { 
            if (angle < leftLockAngle)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
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
                if (Input.GetKey(KeyCode.RightArrow))
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
}
