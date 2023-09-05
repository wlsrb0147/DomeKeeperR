using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    void OnClick()
    {
        
    }

}

