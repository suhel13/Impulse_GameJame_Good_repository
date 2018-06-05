using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    public GameObject LightedUpModel;
    GameObject tempLightedUpModel;
    public GameObject Player;
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
        Stats = Player.GetComponent<PlayerStats>();
        lightUpCon.lightUps.Add(this.gameObject);
    }


    public void onImpusleActive()
    {
        distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);
        if (Stats.waveRange >= distanceToPlayer)
        {
            if (spawned == false)
            {
                timer = distanceToPlayer / Stats.waveRange * 0.6f;
                tempLightedUpModel = Instantiate(LightedUpModel, transform.position, Quaternion.identity);
                tempLightedUpModel.GetComponent<LightedUpObj>().timer = timer;
                tempLightedUpModel.GetComponent<LightedUpObj>().Stats = Stats;
                tempLightedUpModel.GetComponent<LightedUpObj>().parent = this.gameObject;
                spawned = true;
            }
            else
            {
                tempLightedUpModel.GetComponent<LightedUpObj>().duration = 0;
            }
        }
    }


}
