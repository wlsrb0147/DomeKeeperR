using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dome : MonoBehaviour
{
    #region
    [Header("돔")]
    [SerializeField] float Hp;
    [SerializeField] float Def;

    #endregion


    

    void SetDamage(int atk)
    {
        Hp -= atk;  
        if (Hp < 0)
        { 
            //어떻게 처리할건지 모름 ? 
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
