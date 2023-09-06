using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class S_PlayerSkillUpManager : MonoBehaviour
{
    public void UseLightSkill()
    {
        S_GameManager.instance.player.useLightSkill = true;
    }
    public void LightRangeUp()
    {
        S_GameManager.instance.player.GetComponentInChildren<Light2D>().pointLightInnerRadius+= 0.5f;
        S_GameManager.instance.player.GetComponentInChildren<Light2D>().pointLightOuterRadius+= 0.5f;
    }
    public void DrillPowerUP()
    {
        S_GameManager.instance.player.GetComponentInChildren<S_Drill>().damage += 10f;
    }

}
