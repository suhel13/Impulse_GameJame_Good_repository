using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Nps : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public bool followPlayer;
    public bool moveToExit = false;
    public GameObject PressE;

    float distanceToPlayer;
    float timer;
    PlayerStats Stats;
    bool isActive = false;
    public LightUpControler lightUpCon;
    public Transform canvas;
    public Vector3 destynation;
    // Use this for initialization

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Stats = player.GetComponent<PlayerStats>();
        GetComponent<MeshRenderer>().enabled = false;
        lightUpCon.NPSs.Add(this.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (followPlayer)
        {
            transform.LookAt(player.transform);
            destynation = player.transform.position;
            agent.SetDestination(destynation);
            if (Vector3.Distance(player.transform.position, transform.position) >= 7)
            {
                followPlayer = false;
                agent.destination = transform.position;
            }
        }
        else if (moveToExit)
        {
            agent.destination = destynation;
        }


        if (isActive)
        {
            if (timer > 0)
            {
                timer -= Time.fixedDeltaTime;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }           
        }        
    }



    private void OnTriggerStay(Collider other)
    {
        if (isActive && other.tag == "Player"&&followPlayer==false&&moveToExit==false)
        {
            PressE.SetActive(true);
            canvas.transform.eulerAngles = new Vector3(canvas.transform.eulerAngles.x, 0f, transform.eulerAngles.x);
            if (player.GetComponent<PlayerControler>().readyForNps)
            {
                followPlayer = true;
                PressE.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PressE.SetActive(false);
    }

    public void onImpusleActive()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (Stats.waveRange >= distanceToPlayer)
        {
            timer = distanceToPlayer / Stats.waveRange * 0.75f;
            isActive = true;
        }
    }
}
