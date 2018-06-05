using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitZone : MonoBehaviour
{

    Vector3[] positions = new Vector3[] { new Vector3(22.7f, 1, -4.58f), new Vector3(21.7f, 1, -4.58f), new Vector3(20.7f, 1, -4.58f) };
    public int nextSpot = 0;

    public UIControler uIControler;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPS")
        {
            other.GetComponent<Nps>().followPlayer = false;
            other.GetComponent<Nps>().moveToExit = true;
            other.GetComponent<Nps>().agent.stoppingDistance = 0.1f;
            other.GetComponent<Nps>().destynation = positions[nextSpot];
            nextSpot++;
            if (nextSpot == 3)
            {
                Debug.Log("you Win");
                uIControler.activeWonPanel();
            }
        }
    }
}
