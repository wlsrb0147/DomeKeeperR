using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance;
    private DefalutTower dt;
    private Dome dm;
    private FireTower ft;
    private StunTower st;


    [SerializeField] public GameObject defaltTower;
    [SerializeField] public GameObject dome;
    [SerializeField] GameObject UnlockImage;


    public int isAtkUp;
    public int isDefUp;
    #region
    [Header("태크1")]
    [SerializeField] public bool isTech1 = false;
    [SerializeField] public bool isPenetrate = false;
    [SerializeField] public bool isPenetrateUp1 = false;
    [SerializeField] public bool isPenetrateUp2 = false;

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
    [SerializeField] public bool isFireDurUp = false;
    [SerializeField] public bool isFireCoolUp = false;
    [SerializeField] public bool isStunTimeUp = false;
    [SerializeField] public bool isStunSpeedUp = false;
    [SerializeField] public bool isStunAmmoSpeedUp = false;

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
    [SerializeField] public bool isAutoTower = false;
    [SerializeField] public bool isDomeShield = false;
    [SerializeField] public GameObject StunAmmo;
    [SerializeField] public GameObject NonAutoStunAmmo;


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
        if (!dm)
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
            defaltTower.GetComponent<DefalutTower>().Atk += 2;
            isAtkUp += 1;

        }
    }
    public void DefUp()
    {
        if (isDefUp < 5)
        {
            dome.GetComponent<Dome>().Def += 2;
            isDefUp += 1;
        }
    }

    public void DomeHeal()
    {
        dome.GetComponent<Dome>().SetHeal(dome.GetComponent<Dome>().MaxHp / 3);
    }
    public void Tech1Active()
    {
        if (Buttoninteractive.Instance.activeButton == true)
        {
            isTech1 = true;
            defaltTower.GetComponent<DefalutTower>().penetratedCount += 1;
        }
    }
    public void Tech2Active()
    {
        if (Buttoninteractive.Instance.activeButton == true)
        { 
            isTech2 = true;
            EquipSubTower();
        }
    }
    public void Tech3Active()
    {
        if (Buttoninteractive.Instance.activeButton == true)
            isTech3 = true;
    }

    public void PenetrateUp1()
    {
        if (isTech1 && !isCharge)
        {
            defaltTower.GetComponent<DefalutTower>().penetratedCount += 1;
            defaltTower.GetComponent<DefalutTower>().Atk += 2;
            isPenetrateUp1 = true;
        }
    }
    public void PenetrateUp2()
    {
        if (isTech1 && !isCharge && isPenetrateUp1)
        {
            defaltTower.GetComponent<DefalutTower>().penetratedCount += 2;
            defaltTower.GetComponent<DefalutTower>().Atk += 3;
            isPenetrateUp2 = true;
        }
    }
    public void PenetrateUp3()
    {
        if (isTech1 && !isCharge && isPenetrateUp2)
        {
            defaltTower.GetComponent<DefalutTower>().penetratedCount += 3;
            defaltTower.GetComponent<DefalutTower>().Atk += 5;
        }
    }
    public void Charge()
    {
        if (!isPenetrate)
        {
            isCharge = true;
        }
    }
    public void ChargeDelayDown()
    {
        if (!isPenetrate && !isChargeTimeLess && isCharge)
            isChargeDelayLess = true;
    }
    public void ChargeTimeUpgrade()
    {
        if (!isPenetrate && !isChargeDelayLess && isCharge)
            isChargeTimeLess = true;
    }
    //테크2
    public void EquipSubTower()
    {
        if (!isFireTower && !isStunTower)
            SubTower.SetActive(true);
    }
    public void EquipStunTower()
    {
        if (!isFireTower && isTech2)
        {
            StunTower.SetActive(true);
            SubTower.SetActive(false);
            isStunTower = true;
        }
    }
    public void StunTimeUp()
    {
        if (isStunTower && !isStunSpeedUp && !isStunAmmoSpeedUp && isTech2)
        {
            M_GameManager.instance.stunTime += 2f;
            isStunTimeUp = true;
        }

    }
    public void StunCoolDown()
    {
        if (isStunTower && !isStunTimeUp && !isStunAmmoSpeedUp && isTech2)
        {
            StunTower.GetComponent<StunTower>().StunRestCool -= 2f;
            isStunSpeedUp = true;
        }
    }
    public void StunSpeedUp()
    {
        if (isStunTower && !isStunTimeUp && !isStunSpeedUp && isTech2)
        {

            StunAmmo.GetComponent<Stun>().Speed += 10f;
            NonAutoStunAmmo.GetComponent<NonAutoStun>().Speed += 10f;

            isStunAmmoSpeedUp = true;
        }

    }


    public void EquipFireTower()
    {
        if (!isStunTower && isTech2)
        {
            FireTower.SetActive(true);
            SubTower.SetActive(false);
            isFireTower = true;
        }
    }
    public void FireTowerDurUp()
    {
        if (isFireTower && !isFireCoolUp && isTech2)
        {
            FireTower.GetComponent<FireTower>().FireDuartion += 4f;
        }
    }
    public void FireTowerRestDown()
    {
        if (isFireTower && !isFireDurUp && isTech2)
        {
            FireTower.GetComponent<FireTower>().FireRestCool -= 2f;
            isFireCoolUp = true;
        }

    }
    //테크3 

    public void Automatic()
    {
        isTech3 = true;
    }
    public void CreateAutoTower()
    {
        if (isTech3)
        {
            AutoTower.SetActive(true);
            isAutoTower = true;
        }

    }
    public void CreateShield()
    {
        if (isAutoTower && isTech3)
        {
            isShield = true;
            DomeShield.SetActive(true);
            isDomeShield = true;
            UnlockImage.SetActive(false);
        }
    }
    public void CreateSword()
    {
        if (isDomeShield && isTech3)
            SwordTower.SetActive(true);
    }

}
