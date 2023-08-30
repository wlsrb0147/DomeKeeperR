using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
using UnityEngine.SocialPlatforms.Impl;

public class PetController : PetEntity
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        #region Mine
        if (isGrounded)
        {
            MoveVelocity();
            petFly = false;
            underMine = false;
            sideMine = true;
        }

        if (isMineraled)
        {
            ZeroVelocity();
            petFly = false;
            sideMine = false;
            underMine = true;
        }
        if (!isGrounded)
        {
            underMine = false;
            sideMine = false;
            petFly = true;
        }

        if(isSideMineralDetected)
        {
            MoveVelocity();
            petFly = false;
            underMine = false;
            sideMine = true;
        }

        if (!isSideMineralDetected && isGrounded)
        {
            ZeroVelocity();
            petFly = false;
            sideMine = false;
            underMine = true;
        }

        if(!sideCheck && isGrounded)
        {
            ZeroVelocity();
            petFly = false;
            sideMine = false;
            underMine = true;
        }

        #endregion

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreItem"))
        {
            //점수아이템
            //ItemData가져오기
            S_JemStone iron = collision.gameObject.GetComponent<S_JemStone>();
            //점수 얻기
            JemStoneScore += iron.mineralValue;
            //아이템 제거
            Destroy(collision.gameObject);
        }
    }
}