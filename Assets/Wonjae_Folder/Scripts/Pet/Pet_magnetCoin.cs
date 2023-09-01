using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_magnetCoin : MonoBehaviour
{
    public float MineralSpeed;
    public Transform Pet;
    private bool ReadyToMove;
    PetEntity pe = new PetEntity();

    private void Update()
    {
        if (ReadyToMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, Pet.transform.position, MineralSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pet")
        {
            ReadyToMove = true;
            Pet = GameObject.FindWithTag("Pet").transform;
        }
    }
}
