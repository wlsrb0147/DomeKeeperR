 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StunTower : Tower
{
    [SerializeField] public Transform StunPos;

    #region
    [Header("½ºÅÏ")]
    [SerializeField] float StunDuartion;
    [SerializeField] float StunRestCool;
    [SerializeField] float StunRestTime;


    #endregion
    public GameObject Stun;
    public GameObject NonAutoStun;
    private void Start()
    {
        SetRotation();
        Move();
        Attack();
        ShotDelay();
    }


    void ShotDelay()
    {
        StunRestTime += Time.deltaTime;
    }
    void SetRotation()
    {
        if (angle > 1.5 && angle < 1.6)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (angle >= 0.8 && angle <= 0.9)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        if (angle >= 2.3 && angle <= 2.4)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius / 1.5f;


        transform.position = new Vector3(posX, posY);
    }
    void Move()
    {

        if (angle < leftLockAngle)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
               
                    StartCoroutine("AutoStunAtk");
                    StunAttack();
            }
            else 
            {
                StopCoroutine("AutoStunAtk");
        
            }
        }
    }
    

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (StunRestTime > StunRestCool) 
            { 
            StartCoroutine("StunAtk");
            }
        }
        else
        {
            StopCoroutine("StunAtk");
        }
    }

    void StunAttack()
    {
        if (SkillTreeManager.Instance.isTech3 == false)
        {
            GameObject SA = Instantiate(NonAutoStun, StunPos.transform.position, StunPos.transform.rotation);
            Destroy(SA, 5f);
            StunRestTime = 0;
        }
    }
    IEnumerator AutoStunAtk()
    {
        if (SkillTreeManager.Instance.isTech3 == true) { 
        GameObject StunAmmo = Instantiate(Stun, StunPos.transform.position, StunPos.transform.rotation);
        Destroy(StunAmmo, 5f);
        StunRestTime = 0;
        yield return new WaitForSeconds(StunRestCool);
        }
    }                   
}
