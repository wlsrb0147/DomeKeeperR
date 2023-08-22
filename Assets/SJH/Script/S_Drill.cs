using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class S_Drill : MonoBehaviour
{
    public LayerMask wahtisGround;
    public Transform drillPos;

    void Dig()
    {
        Collider2D overCollider2d = Physics2D.OverlapCircle(drillPos.position, 0.01f, wahtisGround);

        if (overCollider2d != null)
        {
            overCollider2d.transform.GetComponent<S_MapGenerator>().MakeDot(drillPos.position);
        }
    }
}
