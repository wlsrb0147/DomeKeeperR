using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Mineral : MonoBehaviour
{
    [SerializeField] float Hp;

    void Start()
    {
        
    }

    void Update()
    {
        if(Hp <= 0)
        {
            Hp = 0;
            Destroy(gameObject);
            
        }
    }
    public void SetDamage(float damage)
    {
        Hp -= damage;
    }
}
