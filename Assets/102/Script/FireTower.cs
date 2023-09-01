using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    [SerializeField] RaycastHit2D hit;
    [SerializeField] LayerMask whatisEnemy;
    [SerializeField] public Transform FirePos;

    #region
    [Header("บา")]
    [SerializeField] float raydistance;
    [SerializeField] float FireDuartion;
    [SerializeField] float FireRestTime;
    [SerializeField] float FireRestCool;
    [SerializeField] bool isFire;

    #endregion
    public GameObject Fire;
    private void Update()
    {
        SetRotation();
        Move();
        RestTimeCheck();
        Detection();
        UpdateFirePosition();
    }

    void RestTimeCheck()
    {
      
        FireRestTime += Time.deltaTime;
    }
    void SetRotation()
    {
        if (angle > 1.5 && angle < 1.6)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
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

    void UpdateFirePosition()
    {
        if (isFire && Fire != null)
        {
            Fire.transform.position = FirePos.transform.position;
        }
    }
    void Detection()
    {
        if (hit = Physics2D.Raycast(transform.position, transform.up, raydistance, whatisEnemy))
        {
            isFire = true;
            if(isFire) { 
            StartCoroutine("CreateFire");
            }
        }
        else
        {
            if (!isFire) { 
            StopCoroutine("CreateFire");
            }
        }
    }

    IEnumerator CreateFire()
    {
      
        if(FireRestTime > FireRestCool )
        { 
        GameObject Firebat = Instantiate(Fire, FirePos.transform.position,FirePos.transform.rotation);
        Destroy(Firebat, 1);
        yield return new WaitForSeconds(FireDuartion);
        FireRestTime = 0f;
        isFire = false;
        }
    }
}
