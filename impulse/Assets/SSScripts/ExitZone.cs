using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitZone : MonoBehaviour
{

    Vector3[] positions = new Vector3[] { new Vector3(22.7f, 1, -4.58f), new Vector3(21.7f, 1, -4.58f), new Vector3(20.7f, 1, -4.58f) };
    int nextSpot = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPS")
        {
            other.GetComponent<Nps>().followPlayer = false;
            other.GetComponent<Nps>().moveToExit = true;
            other.GetComponent<Nps>().agent.stoppingDistance = 0.1f;
            other.GetComponent<Nps>().destynation = positions[nextSpot];
            nextSpot++;

        }
        if (other.tag == "Player" && nextSpot == 3)
        {
            Debug.Log("you Win");
        }
    }
}
