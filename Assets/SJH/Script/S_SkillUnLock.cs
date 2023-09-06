using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_SkillUnLock : MonoBehaviour
{
    public Button button;
    public GameObject UnlockImage;
    [SerializeField] bool useCheck = false;
    [SerializeField] GameObject[] upgradeNode;
    Dome dome;

    int upgradeCount = 0;
    enum SkillName
    {
        light,
        teleport,
        domesheild,
        domeHP,
    }

    [SerializeField] SkillName skillName;

    private void Start()
    {

    }
    private void Update()
    {
        if (skillName == SkillName.domeHP)
        {
            gameObject.GetComponentInChildren<Slider>().value = 100;

            gameObject.GetComponentInChildren<Slider>().value = dome.GetComponent<Dome>().CurHp;
        }
        if (useCheck)
        {
            if (skillName == SkillName.light)
                gameObject.GetComponentInChildren<Slider>().value += (1 / S_GameManager.instance.player.lightCoolTime) * Time.deltaTime;
            else if (skillName == SkillName.teleport)
                gameObject.GetComponentInChildren<Slider>().value += (1 / S_GameManager.instance.player.teleportCoolTime) * Time.deltaTime;
            else if (skillName == SkillName.domesheild)
                gameObject.GetComponentInChildren<Slider>().value = dome.GetComponent<Dome>().Shield;



        }

    }
    public void Unlock()
    {
        UnlockImage.SetActive(false);
        gameObject.GetComponentInChildren<Slider>().value = 100;
        useCheck = true;
    }

    public void UpgradeNode()
    {
        upgradeNode[upgradeCount].SetActive(true);
        upgradeCount++;
        
    }
}
