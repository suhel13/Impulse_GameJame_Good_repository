using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    public GameObject wow;
    GameObject tempWow;
    public GameObject Player;
    PlayerStats Stats;
    float speed;
    float distanceToPlayer;
    public LightUpControler lightUpCon;
    float timer;
    // Use this for initialization
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
            activeTimer(distanceToPlayer / Stats.waveRange-speed * 0.75f);
            tempWow=Instantiate(wow, transform.position, Quaternion.identity);
            tempWow.GetComponent<LightedUpObj>().timer = timer;
            tempWow.GetComponent<LightedUpObj>().Stats = Stats;
        }
    }

  

    void activeTimer(float time)
    {
        timer = time;
    }
}
