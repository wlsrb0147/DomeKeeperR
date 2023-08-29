using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GameManager : MonoBehaviour
{
    string monsterTag = "Monster";
    public Camera mainCamera;

    private void Start()
    {
    }

    private void Update()
    {
        int monsterCount = CountWithTag(monsterTag);
        Debug.Log(" 몬스터 숫자 : " + monsterCount);
    }

    private int CountWithTag(string tag)
    {
        GameObject[] tagNum = GameObject.FindGameObjectsWithTag(tag);
        return tagNum.Length;
    }
}
