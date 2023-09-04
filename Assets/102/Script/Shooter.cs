using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] public GameObject missile;
    [SerializeField] public GameObject target;

    [SerializeField] public float spd;
    [SerializeField] public int shot = 12;

    public void Update()
    {
        target = GameObject.FindGameObjectWithTag("Monster");
        
            Shot();
        
        
    }
    public void Shot()
    {
        StartCoroutine(CreateMissile());
    }

    IEnumerator CreateMissile()
    {
        int _shot = shot;
        while (_shot > 0)
        {
            _shot--;
            GameObject bullet = Instantiate(missile, transform);
            bullet.GetComponent<BezierMissile>().master = gameObject;
            bullet.GetComponent<BezierMissile>().enemy = target;

            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
