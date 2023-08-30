using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class rotationTower : MonoBehaviour
{
    #region 
    [Header("TowerMoveInfo")]
    [SerializeField] Transform rotationCenter;
    [SerializeField] float rotationRadius, angularSpeed;
    [SerializeField] private GameObject lazer;
    [SerializeField] private GameObject lazerend;
    Animator anim;
    float posX, posY, angle = 0f;
    [SerializeField] private float leftLockAngle;
    [SerializeField] private float rightLockAngle;
    [SerializeField] private float rote;
    [SerializeField] private Transform lazerPos;
    [SerializeField] private int raydistance;
    RaycastHit2D lrhit;
    public RaycastHit2D[] lrhits;
    public LineRenderer lr;
    [SerializeField] public LayerMask whatisEnemy;
    [SerializeField] public LayerMask whatisEnd;
    Vector2 pos;
    [SerializeField] float Atk;
    public float rayDistance = 200f;
    [SerializeField] private GameObject animationPrefab;
    private GameObject currentAnimation; // 현재 재생 중인 애니메이션 프리팹
    public Vector3 targetPosition;
    #endregion
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        anim = GetComponent<Animator>();    
    }
    void Update()
    {
        Move();
        SetRotation();
        Attack();
    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            LrDraw();

        }
        if (Input.GetKeyUp(KeyCode.Space))
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
        lr.SetPosition(0, lazerPos.transform.position);


        bool hitEnemy = false;

        if (lrhit = Physics2D.Raycast(transform.position, transform.up, raydistance, whatisEnd))
        {
            lr.SetPosition(1, lrhit.point);
            lr.enabled = true;

        
            if (lrhit.collider.CompareTag("Monster"))
            {
                GameObject hitObject = lrhit.collider.gameObject;
                hitObject.GetComponent<M_Base>().Damage(1);
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
                    hitObject.GetComponent<M_Base>().Damage(1);

                    lr.SetPosition(1, hit.point);
                    lr.enabled = true;

                    Instantiate(lazerend, hit.point, Quaternion.identity);

                    //break; //이것만 지우면 관통형 레이저 가능 
                }
            }
        }


        lr.enabled = true;

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