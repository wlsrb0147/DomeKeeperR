using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestMob : MonoBehaviour
{
    public float HP;
    void Start()
    {
    
    }

 
    void Update()
    {
       
        Debug.Log(HP);
        
    }
    
    public void Damage(float Atk)
    {
        HP -= Atk;
        if (HP <= 0)
        {
            
            Destroy(gameObject);
        }
    }
    
}
