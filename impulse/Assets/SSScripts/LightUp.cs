using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    public GameObject LightedUpModel;
    public GameObject tempLightedUpModel;
    public GameObject player;
    PlayerStats Stats;
    float distanceToPlayer;
    public LightUpControler lightUpCon;
    float timer;
    public bool spawned = false;

    private void Awake()
    {
    }

    void Start()
    {
        Stats = player.GetComponent<PlayerStats>();
        lightUpCon.lightUps.Add(this.gameObject);
    }


    public void onImpusleActive()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (Stats.waveRange >= distanceToPlayer)
        {
                timer = distanceToPlayer / Stats.waveRange * 0.75f;
            if (spawned == false)
            {
                tempLightedUpModel = Instantiate(LightedUpModel, transform.position, Quaternion.identity);
                tempLightedUpModel.GetComponent<LightedUpObj>().timer = timer;
                tempLightedUpModel.GetComponent<LightedUpObj>().Stats = Stats;
                tempLightedUpModel.GetComponent<LightedUpObj>().parent = this.gameObject;
                spawned = true;
            }
            else
            {
                tempLightedUpModel.GetComponent<LightedUpObj>().duration = 0- timer;
            }
        }
    }


}
