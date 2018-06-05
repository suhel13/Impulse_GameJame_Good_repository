using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeObstacles : MonoBehaviour
{

    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerControler>().takeDamage(damage);
        }
    }
}

