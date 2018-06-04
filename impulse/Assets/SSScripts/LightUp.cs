using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    public GameObject wow;
    GameObject tempWow;
    public GameObject Player;
    PlayerStats Stats;
    float duration = 0;
    float distanceToPlayer;
    public LightUpControler lightUpCon;
    bool fixedUpdateEnebled;
    bool spawned = false;
    float timer;
    // Use this for initialization
    void Start()
    {
        Stats = Player.GetComponent<PlayerStats>();
        fixedUpdateEnebled = false;
        lightUpCon.lightUps.Add(this.gameObject);
    }


    public void onImpusleActive()
    {
        distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);
        if (Stats.waveRange >= distanceToPlayer)
        {
            activeTimer(distanceToPlayer / Stats.waveRange * 0.75f);
            fixedUpdateEnebled = true;
            duration = 0;
        }
    }

    IEnumerator IWisiable()
    {
        if (duration <= Stats.waveDelay)
        {
            duration += Time.fixedDeltaTime;
            if (spawned == false)
            {
                tempWow = Instantiate(wow, transform.position, Quaternion.identity);
                spawned = true;
            }
            Debug.Log("tu jest ładny shader");
            yield return null;
        }
    }

    private void FixedUpdate()
    {
        if (fixedUpdateEnebled)
        {
            if (timer <= 0)
            {
                StartCoroutine(IWisiable());
            }
            else
            { timer -= Time.fixedDeltaTime; }

            if (duration > Stats.waveDelay)
            {
                Destroy(tempWow);
                spawned = false;
                duration = 0;
                fixedUpdateEnebled = false;
            }
        }
    }

    void activeTimer(float time)
    {
        timer = time;
    }
}
