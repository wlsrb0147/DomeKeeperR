using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance;
    private DefalutTower dt;
    private Dome dm;
    private FireTower ft;
    private StunTower st;

    public int isAtkUp;
    public int isDefUp;
    #region
    [Header("태크1")]
    [SerializeField] public bool isTech1 = false;
    [SerializeField] public bool isPenetrate = false;
    [SerializeField] public bool isCharge = false;
    [SerializeField] public bool isPenetrateUpgrade1 = false;
    [SerializeField] public bool isPenetrateUpgrade2 = false;
    [SerializeField] public bool isChargeDelayLess = false;
    [SerializeField] public bool isChargeTimeLess = false;
  

    #endregion
    #region
    [Header("태크2")]
    [SerializeField] public bool isTech2 = false;
    [SerializeField] public bool isFireTower = false;
    [SerializeField] public bool isStunTower = false;
    [SerializeField] public GameObject StunTower;
    [SerializeField] public GameObject FireTower;
    [SerializeField] public GameObject SubTower;




    #endregion
    #region
    [Header("태크3")]
    [SerializeField] public bool isTech3 = false;
    [SerializeField] public GameObject SwordTower;
    [SerializeField] public GameObject AutoTower;
    [SerializeField] public GameObject DomeShield;
    [SerializeField] public bool isShield;

    #endregion
    private void Awake()
    {
        Instance = this; // 스킬 트리 매니저의 인스턴스를 설정합니다.
    }
    void Start()
    {
        if (!dt)
        {
            dt = GetComponent<DefalutTower>();
        }
        if(!dm)
        {
            dm = GetComponent<Dome>();
        }
        if (!ft)
        {
            ft = GetComponent<FireTower>();
        }
        if (!st)
        {
            st = GetComponent<StunTower>();
        }
    }
    private void Update()
    {
     
    }

    public void AttackUp()
    {
        if (isAtkUp < 5)
        {
            dt.Atk += 2;
            isAtkUp += 1;
        }
    }
    public void DefUp()
    {
        if (isDefUp < 5)
        {
            dm.Def += 2;
            isDefUp += 1;
        }
    }
    public void Tech1Active() 
    {
        isTech1 = true;
    }
    public void Tech2Active()
    {
        isTech2 = true;
    }
    public void Tech3Active()
    {
        isTech3 = true;
    }

    public void Penetrate()
    {
        dt.penetratedCount += 1;
        dt.Atk += 2;
    }
    public void Charge()
    {
        isCharge = true;
    }
    public void ChargeDelayDown()
    {
        isChargeDelayLess = true;
    }
    public void ChargeTimeUpgrade()
    {
        isChargeTimeLess = true;
    }
    //테크2
    public void EquipSubTower()
    { 
        if(isTech2 == true) 
        {
            SubTower.SetActive(true);
        }
    }
    public void EquipStunTower()
    {
        if (isTech2 == true)
        {
            StunTower.SetActive(true);
            SubTower.SetActive(false);  
        }
    }
    public void StunTimeUp()
    {
        if (isTech2 == true)
        {
            st.StunDuartion += 2f;
        }
    }
    public void StunCoolDown()
    {
        if (isTech2 == true)
        {
            st.StunRestCool -= 2f;
        }
    }
    public void StunSpeedUp()
    {
        if (isTech2 == true)
        {
        
        }
    }




    public void EquipFireTower()
    {
        if (isTech2 == true)
        {
            FireTower.SetActive(true);
            SubTower.SetActive(false);
        }
    }
    public void FireTowerDurUp()
    {
        if (isTech2 == true)
        {
            ft.FireDuartion += 4f;
        
        }
    }
    public void FireTowerRestDown()
    {
        if (isTech2 == true)
        {
            ft.FireRestCool -= 2f;
           
        }
    }
    //테크3 
    public void CreateAutoTower()
    {
        if (isTech3 == true)
        {
            AutoTower.SetActive(true);
        }
    }
    public void CreateShield()
    {
        isShield = true;
        DomeShield.SetActive(true);
    }
    public void CreateSword()
    {
        SwordTower.SetActive(true);
    }

}
