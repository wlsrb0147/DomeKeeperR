using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_SkillTree : MonoBehaviour
{
    public static Pet_SkillTree skillTree;
    private void Awake()
    {
        skillTree = this;
    }

    public int[] SkillLevels;
    public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;

    public List<Pet_Skill> SkillList;
    public GameObject SkillHolder;

    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

    public int SkillPoint;

    private void Start()
    {
        SkillPoint = 20;

        SkillLevels = new int[6];
        SkillCaps = new[] { 1, 5, 5, 2, 10, 10 };

        SkillNames = new[] { "Upgrade 1", "Upgrade 2", "Upgrade 3", "Upgrade 4", "Upgrade 5", "Upgrade 6", };
        SkillDescriptions = new[]
        {
            "Does a thing",
            "Does a cool thing",
            "Does a really cool thing",
            "Does an awesome thing",
            "Does this math thing",
            "Does this compounding thing",
        };

        foreach (var skill in SkillHolder.GetComponentsInChildren<Pet_Skill>()) SkillList.Add(skill);
        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>()) ConnectorList.Add(connector.gameObject);

        for (var i = 0; i < SkillList.Count; i++)
        {
            SkillList[i].id = i;
        }

        SkillList[0].ConnectedSkills = new[] { 1, 2, 3};
        SkillList[1].ConnectedSkills = new[] {4};
        SkillList[2].ConnectedSkills = new[] {5};
        SkillList[3].ConnectedSkills = new[] {6};
        SkillList[5].ConnectedSkills = new[] { 7 };
        SkillList[7].ConnectedSkills = new[] { 8 };

        UpdateSkillUI();
    }

    public void UpdateSkillUI()
    {
        foreach(var skill in SkillList) skill.UpdateUI();
    }
}
