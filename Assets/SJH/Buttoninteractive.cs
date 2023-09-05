using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Buttoninteractive : MonoBehaviour
{
    public bool parentCheck = false;
    public Button parentbutton;
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
            GetComponent<Button>().interactable = false;
    }

}

