using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBig : MonoBehaviour
{
    #region 
    [Header("빅레이저")]
    [SerializeField] private float Atk;


    #endregion

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<M_Base>().Damage(Atk);
            Debug.Log("데미지가" + Atk + "만큼 달아용");
        }
    }

}
