using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ScoreBoard : MonoBehaviour
{
    [SerializeField] GameObject scoreBoard;
    [SerializeField] GameObject map;
    [SerializeField] GameObject skillboard;
    float mapcount =5;
    float skillboardcount = 0f;
    void Update()
    {
        mapcount -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.I))
        {
            mapcount = 5;
           
        }
        if (mapcount <= 0)
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

        if(S_GameManager.instance.player.isDomeCheck && Input.GetKeyDown(KeyCode.K) && skillboardcount == 0)
        {
            skillboard.SetActive(true);
            skillboardcount++;

        }
        else if(Input.GetKeyDown(KeyCode.K) && skillboardcount ==1)
        {
            skillboard.SetActive(false);
            skillboardcount = 0;
        }
    }


}
