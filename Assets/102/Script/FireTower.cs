using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : SubTower
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
    protected override void Update()
    {
        base.Update();
        RestTimeCheck();
        Detection();
        UpdateFirePosition();
    }

    void RestTimeCheck()
    {
      
        FireRestTime += Time.deltaTime;
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
            if (FireRestTime > FireRestCool) 
            { 
            isFire = true;
            }
            if (isFire) { 
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
      
        
        GameObject Firebat = Instantiate(Fire, FirePos.transform.position,FirePos.transform.rotation);
        Destroy(Firebat, 0.2f);
        yield return new WaitForSeconds(FireDuartion);
        FireRestTime = 0f;
        isFire = false;
        
    }
}
