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


    private void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
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
            timer = distanceToPlayer / Stats.waveRange * 0.6f;
            tempLightedUpModel = Instantiate(LightedUpModel, transform.position, Quaternion.identity);
            tempLightedUpModel.GetComponent<LightedUpObj>().timer = timer;
            tempLightedUpModel.GetComponent<LightedUpObj>().Stats = Stats;
        }
    }


}
