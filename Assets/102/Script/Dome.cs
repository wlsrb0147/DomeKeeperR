using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dome : MonoBehaviour
{
    #region
    [Header("µ¼")]

    [SerializeField] float MaxHp;
    [SerializeField] float CurHp;
    [SerializeField] float Def;
    [SerializeField] float trueatk;

    public GameObject Damaged;
    public GameObject DestroyDome;
    [Header("µ¼ ½¯µå")]
    [SerializeField] bool isShield;
    SpriteRenderer SI;
    SpriteRenderer Dd;
    public GameObject ShieldIg;
    [SerializeField] float Shield;
    [SerializeField] float RespawnTime;
    [SerializeField] float CoolTimer;

    [Header("°Ë")]
    [SerializeField] float Atk;

    #endregion

    private void Start()
    {
        SI = ShieldIg.GetComponent<SpriteRenderer>();
        Dd = Damaged.GetComponent<SpriteRenderer>();
        MaxHp = CurHp;
    }

    private void Update()
    {
        if (!isShield)
        {
            CoolTimer += Time.deltaTime;
        }
        if (CoolTimer > RespawnTime)
        {
            isShield = true;
            SI.enabled = true;
        }

    }

    void SetHeal(int heal)
    {
        CurHp += heal;
        if(CurHp > MaxHp) 
        {
            CurHp = MaxHp;
        }
        
    }
    public void SetDamage(float atk)
    {
        if (!isShield)
        {
            trueatk = atk - Def;
            CurHp -= trueatk;

            if (CurHp < MaxHp/2)
            {
                Dd.enabled = true;
            }
            else

                Dd.enabled = false;
            if (CurHp < 0)
            {
                DestroyDome.SetActive(true);
                //¾î¶»°Ô Ã³¸®ÇÒ°ÇÁö ¸ð¸§ ? 
            }
        }
        else if (isShield)
        { 
     
            trueatk = atk - Def;
            Shield -= trueatk;
            if (Shield < 0)
            {
                SI.enabled = false;
                isShield = false;
            }
        }
    }


}
