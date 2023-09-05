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
    private void Start()
    {
     
        isMe = false;
    }
    protected override void Update()
    {
        base.Update();
        ShotDelay();
        Attack();
    }

    protected override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            if (StunRestTime > StunRestCool)
            {
               
                    StartCoroutine("StunAtk");
                
            }
            else 
            {
                StopCoroutine("StunAtk");
        
            }
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
