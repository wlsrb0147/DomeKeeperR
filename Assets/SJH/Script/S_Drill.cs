using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class S_Drill : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] LayerMask wahtisGround;
    [SerializeField] LayerMask wahtisMIneral;
    [SerializeField] Transform drillPos;

    S_Mineral mineral;
    bool mineralCheck;
    private void Start()
    {
        mineral = GetComponent<S_Mineral>();
    }

    private void Update()
    {
    }
    void Dig()
    {
        Collider2D groundCollider2d = Physics2D.OverlapCircle(drillPos.position, 0.01f, wahtisGround);
        Collider2D mineralCollider2d = Physics2D.OverlapCircle(drillPos.position, 0.01f, wahtisMIneral);

        if(mineralCollider2d != null  )
        {
            mineralCollider2d.transform.GetComponent<S_Mineral>().SetDamage(damage);
        }
        else if (groundCollider2d != null && !mineralCheck)
        {
            groundCollider2d.transform.GetComponent<S_MapGenerator>().MakeDot(drillPos.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mineral"))
        {
            mineralCheck = true;
        }
        else
            mineralCheck = false;  
    }




}
