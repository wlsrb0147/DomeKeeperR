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
    public bool parentCheck = false;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    private void Update()
    {
        if (parentbutton.interactable == false)
            parentCheck = true;
        else
            parentCheck = false;
    }
    public void OnClick()
    {
        if (parentCheck)
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

