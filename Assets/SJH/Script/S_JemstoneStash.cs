using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_JemstoneStash : MonoBehaviour
{
    [Header("Score Info")]
    public float redjemScore = 0;
    public float greenjemScore = 0;
    public float bluejemScore = 0;

    Animator anim;
    [SerializeField] GameObject player;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && S_GameManager.instance.player.isDomeCheck)
        {
            player.SetActive(false);
            anim.SetBool("On", true);
            count++;
        }
        else if(Input.GetKeyDown(KeyCode.LeftControl) && count == 1)
        {
            player.SetActive(true);
            anim.SetBool("On", false);
            count = 0;
        }

    }
}
