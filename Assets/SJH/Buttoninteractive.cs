using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Buttoninteractive : MonoBehaviour
{
    [Header("Price")]
    [SerializeField] float redjemPrice;
    [SerializeField] float bluejemPrice;
    [SerializeField] float greenjemPrice;

    [SerializeField] Button parentbutton;
    [SerializeField] Button[] otherTech;
    public bool parentCheck = false;
    public bool otherCheck = true;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void Update()
    {

        if (parentbutton.interactable == false)
            parentCheck = true;
        else
        {
            parentCheck = false;
            otherCheck = false;

        }
        if (otherTech.Length > 0)
        {
            for (int i = 0; i < otherTech.Length; i++)
            {
                if (otherTech[i].interactable == false)
                {
                    otherCheck = false;
                    break;
                }

                if (otherTech[i].interactable == true)
                    otherCheck = true;
            }
        }
        else
            otherCheck = true;
        
    }

    public void OnClick()
    {
        if (parentCheck && otherCheck)
        {
            if (S_GameManager.instance.stash.redjemScore >= redjemPrice
            && S_GameManager.instance.stash.bluejemScore >= bluejemPrice
            && S_GameManager.instance.stash.greenjemScore >= greenjemPrice)
            {
                GetComponent<Button>().interactable = false;

                S_GameManager.instance.stash.redjemScore -= redjemPrice;
                S_GameManager.instance.stash.bluejemScore -= bluejemPrice;
                S_GameManager.instance.stash.greenjemScore -= greenjemPrice;
            }
        }
    }
}

