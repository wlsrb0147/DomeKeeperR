using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_SkillManager : MonoBehaviour
{
    public static Pet_SkillManager instance;
    public Pet_Skill[] skills;
    public Pet_SkillButton[] skillButtons;

    public Pet_Skill activateSkill;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
