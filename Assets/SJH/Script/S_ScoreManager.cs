using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ScoreManager : MonoBehaviour
{
    [SerializeField] Text redjemScore;
    [SerializeField] Text bluejemScore;
    [SerializeField] Text greenjemScore;

    void Update()
    {
        redjemScore.text = S_GameManager.instance.player.redjemScore.ToString();
        bluejemScore.text = S_GameManager.instance.player.bluejemScore.ToString();
        greenjemScore.text = S_GameManager.instance.player.greenjemScore.ToString();
    }
}
