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
        OnMine();
    }

    public void OnMine()
    {
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
            ZeroVelocity();
            underMine = false;
            sideMine = false;
            petFly = true;
        }

        if (isSideMineralDetected)
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

        if (!sideCheck && isGrounded)
        {
            ZeroVelocity();
            petFly = false;
            sideMine = false;
            underMine = true;
        }

        if (isPetCooldown == true)
        {
            petIdle = true;
            petFly = false;
            sideMine = false;
            underMine = false;
        }
        #endregion
    }


    public void DamageUpgrade()
    {
        if (S_GameManager.instance.stash.redjemScore >= Buttoninteractive.Instance.redjemPrice
            && S_GameManager.instance.stash.bluejemScore >= Buttoninteractive.Instance.bluejemPrice
            && S_GameManager.instance.stash.greenjemScore >= Buttoninteractive.Instance.greenjemPrice)
            PetDamageLv2();
        
    }
    public void DamageUpgrade2() 
    {
        if (S_GameManager.instance.stash.redjemScore >= Buttoninteractive.Instance.redjemPrice
            && S_GameManager.instance.stash.bluejemScore >= Buttoninteractive.Instance.bluejemPrice
            && S_GameManager.instance.stash.greenjemScore >= Buttoninteractive.Instance.greenjemPrice)
            PetDamageLv3(); 
    }
    public void CarryUpgrade()
    {
        if (S_GameManager.instance.stash.redjemScore >= Buttoninteractive.Instance.redjemPrice
            && S_GameManager.instance.stash.bluejemScore >= Buttoninteractive.Instance.bluejemPrice
            && S_GameManager.instance.stash.greenjemScore >= Buttoninteractive.Instance.greenjemPrice)
            PetCarryLv2();
    }
    public void CarryUpgrade2() => PetCarryLv3();
    public void ScanUpgrade()
    {
        if(S_GameManager.instance.stash.redjemScore >= Buttoninteractive.Instance.redjemPrice
            && S_GameManager.instance.stash.bluejemScore >= Buttoninteractive.Instance.bluejemPrice
            && S_GameManager.instance.stash.greenjemScore >= Buttoninteractive.Instance.greenjemPrice)
        PetScanLv2();
    }
    public void ScanUpgrade2() => PetScanLv3();
    public void coolTimeUpgrade() => PetCoolTimeUpgrade();
    public void doublePetUpgrade() => DoublePet();

}