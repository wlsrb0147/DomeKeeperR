using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_SkillUnLock : MonoBehaviour
{
    public Button button;
    public GameObject UnlockImage;
    [SerializeField] bool useCheck;
    // float lightCoolDownSpeed;
    //float teleportCoolDownSpeed;


    private void Start()
    {

    }
    private void Update()
    {
        if (UnlockImage == true)
        {
            gameObject.GetComponentInChildren<Slider>().value += (1 / S_GameManager.instance.player.lightCoolTime) * Time.deltaTime;
        }

    }
    public void Unlock()
    {
        UnlockImage.SetActive(false);
        gameObject.GetComponentInChildren<Slider>().value = 100;
    }

}
