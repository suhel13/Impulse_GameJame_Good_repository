using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{

    public int healAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControler>().takeHeal(healAmount))
        {
            GetComponent<LightUp>().lightUpCon.lightUps.Remove(this.gameObject);
            Destroy(GetComponent<LightUp>().tempLightedUpModel);
            Destroy(this.gameObject);
        }
    }

}
