using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ScoreManager : MonoBehaviour
{
    [SerializeField] Text redjemScore;
    [SerializeField] Text bluejemScore;
    [SerializeField] Text greenjemScore;

    [SerializeField] Text petRedjemScore;
    [SerializeField] Text petBluejemScore;
    [SerializeField] Text petGreenjemScore;

    public GameObject stash;

    void Update()
    {
        redjemScore.text = S_GameManager.instance.player.redjemScore.ToString();
        bluejemScore.text = S_GameManager.instance.player.bluejemScore.ToString();
        greenjemScore.text = S_GameManager.instance.player.greenjemScore.ToString();

        /*        redjemScore.text = (stash.GetComponent<S_JemstoneStash>().redjemScore + S_GameManager.instance.player.redjemScore).ToString() ;
                bluejemScore.text = (stash.GetComponent<S_JemstoneStash>().bluejemScore + S_GameManager.instance.player.bluejemScore).ToString(); ;
                greenjemScore.text = (stash.GetComponent<S_JemstoneStash>().greenjemScore+S_GameManager.instance.player.greenjemScore).ToString(); ;*/

        petRedjemScore.text = (S_GameManager.instance.pet.redjemScore+ S_GameManager.instance.pet2.redjemScore).ToString();
        petBluejemScore.text = (S_GameManager.instance.pet.bluejemScore + S_GameManager.instance.pet2.bluejemScore).ToString();
        petGreenjemScore.text = (S_GameManager.instance.pet.greenjemScore + S_GameManager.instance.pet2.greenjemScore).ToString();

        Debug.Log(stash.GetComponent<S_JemstoneStash>().redjemScore);


    }
}
