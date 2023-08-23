using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class PetController : PetEntity
{
    [Header("Pet Info")]
    [SerializeField] private float petSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] float P_attack;
    [SerializeField] bool isMoving;

    public S_Mineral mineral;

    GameObject[] targetMineral;
    Transform[] MineralTrs;
    float[] PetAndMineralDist;

    private Transform PetTr;
    private Transform targetTr;
    private int targetint = 0;

    private NavMeshAgent nvAgent;


    protected override void Start()
    {
        base.Start();
        mineral = GetComponent<S_Mineral>();
        targetMineral = GameObject.FindGameObjectsWithTag("MIneral");
        MineralTrs = new Transform[targetMineral.Length];

        for (int i = 0; i < targetMineral.Length; i++)
        {
            MineralTrs[i] = targetMineral[i].GetComponent<Transform>();
        }
        targetTr = MineralTrs[0];
        StartCoroutine(SearchTarget());
    }

    IEnumerator SearchTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            for (int i = 0; i < targetMineral.Length; i++)
            {
                if (PetAndMineralDist[targetint] <= PetAndMineralDist[i + 1])
                {
                    targetTr = MineralTrs[targetint];
                }
            }
        }
        nvAgent.destination = targetTr.position;
        targetint = 0;
    }

    protected override void Update()
    {
        base.Update();



    }



    void PetUnderMine()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(footPos.position, 0.4f, whatIsGround);
        Collider2D mineralCollider = Physics2D.OverlapCircle(footPos.position, 0.4f, WhatIsMineral);

        if (groundCollider != null)
        {
            groundCollider.transform.GetComponent<S_MapGenerator>().MakeDot(footPos.position);
        }
        else if (mineralCollider != null)
        {
            mineralCollider.transform.GetComponent<S_Mineral>().SetDamage(P_attack);
        }

    }


    void PetSideMine()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(toothPos.position, 0.5f, whatIsGround);
        Collider2D mineralCollider = Physics2D.OverlapCircle(toothPos.position, 0.5f, WhatIsMineral);

        if (groundCollider != null)
        {
            groundCollider.transform.GetComponent<S_MapGenerator>().MakeDot(toothPos.position);
        }
        else if (mineralCollider != null)
        {
            mineralCollider.transform.GetComponent<S_Mineral>().SetDamage(P_attack);
        }

    }
}