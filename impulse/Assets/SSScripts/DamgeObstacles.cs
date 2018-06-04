using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeObstacles : MonoBehaviour
{

    int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerControler>().takeDamage(damage);
    }
}

