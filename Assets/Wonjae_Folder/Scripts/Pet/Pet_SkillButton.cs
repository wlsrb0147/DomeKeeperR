using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet_SkillButton : MonoBehaviour
{
    public Image skillImage;
    public Text skillNameText;
    public Text skillDesText;

    public int skillButtonId;
    
    public void PressSkillButton()
    {
        Pet_SkillManager.instance.activateSkill = transform.GetComponent<Pet_Skill>();

        skillImage.sprite = Pet_SkillManager.instance.skills[skillButtonId].skillSprite;
        skillNameText.text = Pet_SkillManager.instance.skills[skillButtonId].skillName;
        skillDesText.text = Pet_SkillManager.instance.skills[skillButtonId].skillDes;
    }
}
