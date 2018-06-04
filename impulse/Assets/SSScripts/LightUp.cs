using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    public GameObject wow;
    GameObject tempWow;
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
            tempWow = Instantiate(wow, transform.position, Quaternion.identity);
            tempWow.GetComponent<LightedUpObj>().timer = timer;
            tempWow.GetComponent<LightedUpObj>().Stats = Stats;
        }
    }


}
