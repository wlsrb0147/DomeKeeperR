using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class PetEntity : MonoBehaviour
{
    [Header("펫 정보")]
    [Tooltip("펫의 이동속도")]
    [SerializeField] protected float petSpeed;

    [Tooltip("펫의 현재 공격력")]
    [SerializeField] private float petDamage;

    [Tooltip("아랫방향 공격")]
    [SerializeField] protected Transform footPos;

    [Tooltip("정면 공격")]
    [SerializeField] protected Transform toothPos;

    [Header("보유한 광물의 수")]
    public float redjemScore = 0f;
    public float greenjemScore = 0f;
    public float bluejemScore = 0f;

    public float maxScore = 10.0f;

    [Header("펫의 스킬 레벨")]
    [SerializeField] public int attackLv = 1; // 공격 레벨
    [SerializeField] public int carryLv = 1; // 가방 무게도 레벨
    [SerializeField] public int scanLv = 1; // 시야 레벨

    [Header("충돌 체크")]
    [Tooltip("펫이 닿고있는 지면을 확인합니다.")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected private float groundCheckDistance;

    [Tooltip("아랫 방향의 미네랄을 감지합니다.")]
    [SerializeField] protected Transform mineralUnderCheck;
    [SerializeField] protected float mineralCheckDistance;

    [Tooltip("바라보는 방향에 미네랄을 임의의 값만큼 감지합니다.")]
    [SerializeField] protected Transform sideMineralCheck;
    [SerializeField] protected float sideMineralCheckDistance;

    [Tooltip("정면에 광물이 무엇인지 감지합니다.")]
    [SerializeField] protected Transform sideCheck;
    [SerializeField] protected float sideCheckDistance;

    [Tooltip("펫 뒤에 미네랄이 있는지 감지합니다.")]
    [SerializeField] protected Transform backCheck;
    [SerializeField] protected float backCheckDistance;

    [Tooltip("벽을 체크하여 방향전환을 결정합니다.")]
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;

    [Header("레이어 체크")]
    [SerializeField] protected private LayerMask whatIsGround;
    [SerializeField] protected private LayerMask whatIsWall;
    [SerializeField] protected private LayerMask WhatIsMineral;
    [SerializeField] protected private LayerMask WhatIsSideTile;

    //방향 전환
    protected int facingDir = -1;
    protected bool facingRight = true;
    bool hardTileCheck;

    //컴포넌트
    protected Rigidbody2D rbody;
    protected Animator anim;
    protected SpriteRenderer spr;
    private Light2D _light;

    //
    S_Mineral mineral;

    #region anim bool
    protected bool isGrounded;
    protected bool isWallDetected;
    protected bool isMineraled;
    protected bool isSideDetected;
    protected bool isSideMineralDetected;
    protected bool isBackDetected;
    protected bool petMove;
    protected bool underMine;
    protected bool sideMine;
    protected bool petIdle;
    protected bool petFly;
    protected bool hasFlipped = false;
    #endregion


    protected virtual void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        mineral = GetComponent<S_Mineral>();
        _light = GetComponent<Light2D>();
    }

    protected virtual void Update()
    {
        CollisionChecks();
        PetAnimatorControllers();
        FlipController();
    }

    #region Flip 
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void FlipController()
    {
        if (isWallDetected)
        {
            Debug.Log("Flip");
            Flip();
        }
        else if (isBackDetected)
        {
            if (!hasFlipped)
            {
                sideMine = true;
                underMine = false;
                petIdle = false;
                petMove = false;
                Flip();
                hasFlipped = true;
            }
        }
        else
        {
            hasFlipped = false;
        }
    }

    #endregion


    #region CollisionChecks
    protected virtual void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, new Vector2(0,0f -0.1f), groundCheckDistance, whatIsGround);
        isWallDetected = Physics2D.Raycast(wallCheck.position, Vector2.left, wallCheckDistance * -facingDir, whatIsWall);

        isMineraled = Physics2D.Raycast(mineralUnderCheck.position, Vector2.down, mineralCheckDistance, WhatIsMineral);
        isSideMineralDetected = Physics2D.Raycast(sideMineralCheck.position, new Vector2(-1.0f, 0.0f), sideMineralCheckDistance * -facingDir, WhatIsMineral);

        isBackDetected = Physics2D.Raycast(backCheck.position, Vector2.right,backCheckDistance * facingDir, WhatIsMineral);
        isSideDetected = Physics2D.Raycast(sideCheck.position, new Vector2(-0.5f, 0.0f), sideCheckDistance * -facingDir, WhatIsSideTile);

    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(sideCheck.position, new Vector3(sideCheck.position.x + sideCheckDistance * facingDir, sideCheck.position.y));
        Gizmos.DrawLine(sideMineralCheck.position, new Vector3(sideMineralCheck.position.x + sideMineralCheckDistance * facingDir, sideMineralCheck.position.y));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(mineralUnderCheck.position, new Vector3(mineralUnderCheck.position.x, mineralUnderCheck.position.y - mineralCheckDistance));

        Gizmos.color = Color.black;
        Gizmos.DrawLine(backCheck.position, new Vector3(backCheck.position.x + backCheckDistance * -facingDir, backCheck.position.y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stash"))
        {


        }
    }


    #endregion


    #region Velocity
    public void ZeroVelocity() => rbody.velocity = Vector2.zero;
    public void MoveVelocity() => rbody.velocity = new Vector2(petSpeed * facingDir, rbody.velocity.y);

    #endregion

    //
    #region Animaition
    private void PetAnimatorControllers()
    {
        /*Pet_Dog Anim*/
        anim.SetBool("Pet_Move", petMove);
        anim.SetBool("Pet_idle", petIdle);
        anim.SetBool("Pet_Fly", petFly);
        anim.SetBool("Under_Mine", underMine);
        anim.SetBool("Side_Mine", sideMine);
        /*pet_Dog Anim Finish*/
    }

    void PetUnderMine()
    {
        Collider2D groundCollider2d = Physics2D.OverlapCircle(footPos.position, 0.05f, whatIsGround);
        Collider2D mineralCollider2d = Physics2D.OverlapCircle(footPos.position, 0.05f, WhatIsMineral);

        if (mineralCollider2d != null)
        {
            mineralCollider2d.transform.GetComponent<S_Mineral>().SetDamage(petDamage);
        }
        else if (groundCollider2d != null && !hardTileCheck)
        {
            groundCollider2d.transform.GetComponent<S_MapGenerator>().MakeDot(footPos.position);
        }
    }

    void PetSideMine()
    {
        Collider2D groundCollider2d = Physics2D.OverlapCircle(toothPos.position, 0.01f, whatIsGround);
        Collider2D mineralCollider2d = Physics2D.OverlapCircle(toothPos.position, 0.01f, WhatIsMineral);

        if (mineralCollider2d != null)
        {
            mineralCollider2d.transform.GetComponent<S_Mineral>().SetDamage(petDamage);
        }
        else if (groundCollider2d != null && !hardTileCheck)
        {
            groundCollider2d.transform.GetComponent<S_MapGenerator>().MakeDot(toothPos.position);
        }
    }
    #endregion

    #region Pet Skill

    protected void PetDamageLv2()
    {
        if (attackLv == 1 && redjemScore >= 5.0f)
        {
            petDamage += 5.0f;
            redjemScore -= 5.0f;
            attackLv = 2;
        }
    }

    protected void PetDamageLv3()
    {
        if (attackLv == 2 && redjemScore >= 10.0f && greenjemScore >= 1.0f) 
        {
            petDamage += 10.0f;
            redjemScore -= 10.0f;
            greenjemScore -= 1.0f;
            attackLv = 3;
        }
    }

    protected void PetCarryLv2()
    {
        if (carryLv == 1 && redjemScore >= 10.0f)
        {
            maxScore = 20;
            redjemScore -= 10.0f;
            carryLv = 2;
        }
    }

    protected void PetCarryLv3()
    {
        if (carryLv == 2 && redjemScore >= 15.0f && greenjemScore >= 5.0f)
        {
            maxScore = 30;
            redjemScore -= 15.0f;
            greenjemScore -= 5.0f;
            carryLv = 3;
        }
    }

    protected void PetScanLv2()
    {
        if (scanLv == 1 && redjemScore >= 5.0f)
        {
            _light.pointLightOuterRadius = 5.0f;
            redjemScore -= 5.0f;
            scanLv = 2;
        }
    }

    protected void PetScanLv3()
    {
        if (scanLv == 2 && redjemScore >= 10.0f && greenjemScore >= 5.0f)
        {
            _light.pointLightOuterRadius = 10.0f;
            redjemScore -= 5.0f;
            greenjemScore -= 5.0f;
            scanLv = 3;
        }
    }

    protected void PetCoolTime()
    {

    }

    protected void PetDouble()
    {

    }

    #endregion


}
