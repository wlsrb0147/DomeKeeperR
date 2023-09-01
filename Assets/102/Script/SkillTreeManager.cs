using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance;

    #region
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
    #endregion
    #region
    [Header("태크3")]
    [SerializeField] public bool isTech3 = false;
    #endregion
    private void Awake()
    {
        Instance = this; // 스킬 트리 매니저의 인스턴스를 설정합니다.
    }
    private void Update()
    {
        SelectTech1();
        SelectTech2();
        SelectTech3();

    }


    void SelectTech1()
    { 
        if(isTech1) 
        {
            isTech2 = false;
            isTech3 = false;
        }
    }
    void SelectTech2()
    {
        if (isTech2)
        {
            isTech1 = false;
            isTech3 = false;
        }
    }
    void SelectTech3()
    {
        if (isTech3)
        {
            isTech1 = false;
            isTech2 = false;
        }
    }
}
