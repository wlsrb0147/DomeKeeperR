using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class M_Flyer : M_Moving
{
    [Header("받아오는 값")] 
    public Collider2D active; // attack,hit때의 collider
    public Collider2D inactive; // apper,hide때의 collider
    public Transform shootPosition;
    public GameObject bullet;


    public M_FlyerAppear appear {  get; private set; }
    public M_FlyerAttack attack { get; private set; }
    public M_FlyerDead dead { get; private set; }
    public M_FlyerHide hide { get; private set; }
    public M_FlyerHit hit { get; private set; }
    public M_FlyerMove move { get; private set; }


    public int attackTimes { get; set; }
    public int currentAttackTimes { get; set; }

    [Header("Test")]
    public Vector2 myposition;   
    public Vector2 moveLocation;
    public Vector2 path;
    public Vector2 centerVec;
    public Vector2 testVec;
    public Vector2 normalVec;
    public Vector2 curve;
    public Vector2 test1;
    public Vector2 test2;
    public Vector2 test3;
    public float multi;
    
    
    
   
    public float x;


    protected override void Awake()
    {
        base.Awake();
        appear = new M_FlyerAppear(this, stateMachine, "Appear", this);
        attack = new M_FlyerAttack(this, stateMachine, "Attack", this);
        dead = new M_FlyerDead(this, stateMachine, "Dead", this);
        hide = new M_FlyerHide(this, stateMachine, "Hide", this);
        hit = new M_FlyerHit(this, stateMachine, "Hit", this);
        move = new M_FlyerMove(this, stateMachine, "Move", this);

        stateMachine.Initiate(move);


        active.enabled = false;
        inactive.enabled = false;
        
        int x = (int)((Random.Range(1, 3) - 1.5) * 2);
        moveLocation = new Vector3(Random.Range(2f, 15f)*x, Random.Range(-2f, 5f),0);

    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.ChangeState(dead);
        }
    }

/*        public Vector2 FlyerMove()
    {
        flyerVec = new Vector2((moveLocation.x - transform.position.x),
                (moveLocation.y - transform.position.y));
        flyerVec = flyerVec.normalized;
        return flyerVec;
    }*/

    public void EndHide()
    {
        stateMachine.ChangeState(move);
    }

    public void EndApper()
    {
        stateMachine.ChangeState(attack);
    }

    public void EndAttack()
    {
        currentAttackTimes++;
    }

    public void EndMove()
    {
        stateMachine.ChangeState(appear);
    }

    public Vector2 Curve(Vector2 start,Vector2 path,Vector2 destination, float timing)
    { 
        float abx, bcx , abcx, aby,bcy,abcy ;
        Vector2 vec;
        abx = Mathf.Lerp(start.x, path.x, timing);
        aby = Mathf.Lerp(start.y, path.y, timing);

        test1 = new Vector2(abx, aby);

        bcx = Mathf.Lerp(path.x, destination.x, timing);
        bcy = Mathf.Lerp(path.y,destination.y, timing);

        test2 = new Vector2(bcx, bcy);

        abcx = Mathf.Lerp(abx, bcx, timing);
        abcy = Mathf.Lerp(aby, bcy, timing);

        test3 = new Vector2(abcx, abcy);

        vec = new Vector2(abcx, abcy);

        return vec;
    }

    public void Shoot()
    {
        GameObject bulletPrefab = Instantiate(bullet, shootPosition.position, transform.rotation);
        bulletPrefab.SetActive(true);
    }

    public float vectorLength(Vector2 vec1,Vector2 vec2)
    {
        float x;
        Vector2 wantLength;
        wantLength = new Vector2(vec1.x - vec2.x, vec1.y - vec2.y);
        x = wantLength.magnitude;

        return x;
    }
}

