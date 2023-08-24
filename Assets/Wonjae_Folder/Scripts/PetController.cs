using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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
            sideMine = true;
            underMine = false;
        }

        if (isMineraled)
        {
            ZeroVelocity();
            sideMine = false;
            underMine = true;
        }

    }


}