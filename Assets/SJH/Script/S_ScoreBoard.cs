using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ScoreBoard : MonoBehaviour
{
    [SerializeField] GameObject scoreBoard;
    [SerializeField] GameObject map;
    [SerializeField] GameObject Skill;
    float count =5;
    void Update()
    {
        count -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.I))
        {
            scoreBoard.SetActive(true);
            count = 5;
           
        }
        if (count <= 0)
        {
            scoreBoard.SetActive(false);
        }

        if(Input.GetKey(KeyCode.Tab))
        {
            map.SetActive(true);
        }
        else
        {
            map.SetActive(false);
        }
    }

    public void ActiveTrueSkill()
    {
        Skill.SetActive(true);
    }

    public void ActiveFalseSkill()
    {
        Skill.SetActive(false);
    }


}
