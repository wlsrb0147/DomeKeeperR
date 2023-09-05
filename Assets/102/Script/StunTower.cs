 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StunTower : SubTower
{
    [SerializeField] public Transform StunPos;

    #region
    [Header("½ºÅÏ")]
    [SerializeField] float StunDuartion;
    [SerializeField] float StunRestCool;
    [SerializeField] float StunRestTime;


    #endregion
    public GameObject Stun;
    protected override void Update()
    {
        base.Update();
        SetRotation();
        Move();
        ShotDelay();
        Attack();
    }

    void Attack()
    {
        if (StunRestTime > StunRestCool)
        {
            StartCoroutine("StunAtk");
        }
        else 
        {
                StopCoroutine("StunAtk");
        
        }
    }
    

    void ShotDelay()
    {
        StunRestTime += Time.deltaTime;
    }
    
  
    IEnumerator StunAtk()
    {
        GameObject StunAmmo = Instantiate(Stun, StunPos.transform.position, StunPos.transform.rotation);
        Destroy(StunAmmo, 5f);
        StunRestTime = 0;
        yield return new WaitForSeconds(StunRestCool); 
        
    }                   
}
