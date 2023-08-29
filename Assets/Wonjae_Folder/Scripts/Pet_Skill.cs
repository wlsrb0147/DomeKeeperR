using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Marker Skill Detail Info.
public class Pet_Skill : MonoBehaviour
{
    public string skillName;
    public Sprite skillSprite;

    [TextArea(1, 3)]
    public string skillDes;
    public bool isUpgrade;
}
