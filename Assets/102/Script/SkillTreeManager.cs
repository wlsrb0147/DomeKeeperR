using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance;

    #region
    public int id;
    [Header("태크1")]
    [SerializeField] public bool isTech1 = false;
    [SerializeField] public bool isPenetrate = false;
    [SerializeField] public bool isCharge = false;
    [SerializeField] public bool isPenetrateUpgrade1 = false;
    [SerializeField] public bool isPenetrateUpgrade2 = false;
    [SerializeField] public bool isChargeDelayless = false;
    [SerializeField] public bool isChargeTimeLess = false;
  

    #endregion
    #region
    [Header("태크2")]
    [SerializeField] public bool isTech2 = false;
    [SerializeField] public bool isFireTower = false;
    [SerializeField] public bool isStunTower = false;
    [SerializeField] public GameObject StunTower;
    [SerializeField] public GameObject FireTower;



    #endregion
    #region
    [Header("태크3")]
    [SerializeField] public bool isTech3 = false;
    #endregion
    private void Awake()
    {
        Instance = this; // 스킬 트리 매니저의 인스턴스를 설정합니다.
    }
    void Start()
    {
       
    }
    private void Update()
    {
      
        SetActive();

    }

    void SetActive()
    {
        if (isStunTower == true)
        {
            StunTower.SetActive(true);
        }
        if (isFireTower == true)
        {
            FireTower.SetActive(true);
        }
    }
    void AttackUp()
    {
     
    }
    
}
