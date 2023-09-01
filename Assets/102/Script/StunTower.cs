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


    #endregion
    public GameObject Stun;
    void Update()
    {
        SetRotation();
        Move();
        Attack();
       
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

                angle = angle + Time.deltaTime * angularSpeed;
                transform.Rotate(0, 0, rote);
                if (angle >= leftLockAngle)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }
        }

        if (angle > rightLockAngle)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                angle = angle + Time.deltaTime * -angularSpeed;
                transform.Rotate(0, 0, -rote);
                if (angle <= rightLockAngle)
                {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                }
            }
        }

    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            StartCoroutine("StunAtk");
        }
        else
        {
            StopCoroutine("StunAtk");
        }
    }

  
    IEnumerator StunAtk()
    {
        GameObject StunAmmo = Instantiate(Stun, StunPos.transform.position, StunPos.transform.rotation);
        Destroy(StunAmmo, 5f);
        yield return new WaitForSeconds(StunRestCool); 
    }
}
