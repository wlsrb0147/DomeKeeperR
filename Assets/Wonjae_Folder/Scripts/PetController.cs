using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class PetController : PetEntity
{

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (isGrounded)
        {
            MoveVelocity();
            sideMine = false;
            underMine = false;
            petIdle = false;
            petFly = false;
            petMove = true;
            Debug.Log("¶¥ À§");
        }

        if (isGrounded && !isSideDetected)
        {
            ZeroVelocity();
            petIdle = false;
            petMove = false;
            sideMine = false;
            petFly = false;
            underMine = true;
            Debug.Log("¶¥ À§ÀÎµ¥ ¿·¿¡ ¾Æ¹«°Íµµ ¾øÀ½");
        }

        if (isGrounded && isSideDetected)
        {
            MoveVelocity();
            petMove = false;
            sideMine = false;
            petIdle = false;
            petFly = false;
            underMine = true;
            Debug.Log("¶¥ À§ÀÎµ¥ ¿·¿¡ º®ÀÖÀ½");
        }

        if (isGrounded && isSideMineralDetected)
        {
            MoveVelocity();
            petMove = false;
            underMine = false;
            petIdle = false;
            petFly = false;
            sideMine = true;
            Debug.Log("¶¥ À§ÀÎµ¥ ¿·¿¡ ¹Ì³×¶öÀÖÀ½");
        }

        if (isMineraled && isSideDetected)
        {
            ZeroVelocity();
            petIdle = false;
            petMove = false;
            sideMine = false;
            petFly = false;
            underMine = true;
            Debug.Log("¹Ì³×¶ö À§ÀÎµ¥ ¿·¿¡ º®");
        }

        if (!isGrounded)
        {
            Debug.Log("°øÁß¿¡ ¶ä");
            ZeroVelocity();
            sideMine = false;
            underMine = false;
            petIdle = false;
            petMove = false;
            petFly = true;
        }

    }

}