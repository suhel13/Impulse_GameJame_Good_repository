using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightedUpObj : MonoBehaviour
{

    public PlayerStats Stats;
    float duration = 0;
    float distanceToPlayer;
    public float timer=0.1f;
    bool spawned;

    // Use this for initialization
    void Awake()
    {
        if (this.gameObject.GetComponent<MeshRenderer>()==null)
        {
            foreach  (MeshRenderer meshrend in transform.GetComponentsInChildren<MeshRenderer>())
            {
                meshrend.enabled = false;
            }
        }
        else
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <= 0)
        {
            if (this.gameObject.GetComponent<MeshRenderer>() == null)
            {
                foreach (MeshRenderer meshrend in transform.GetComponentsInChildren<MeshRenderer>())
                {
                    meshrend.enabled = true;
                }
            }
            else
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            duration += Time.fixedDeltaTime;
        }
        else
        { timer -= Time.fixedDeltaTime; }

        if (duration > Stats.waveDelay)
        {
            Destroy(this.gameObject);

        }
    }

}
