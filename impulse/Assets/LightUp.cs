using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    public GameObject wow;

    public GameObject Player;
    PlayerStats Stats;
    float duration = 0;
    public LightUpControler lightUpCon;
    bool fixedUpdateEnebled;
    // Use this for initialization
    void Start()
    {
        Stats = Player.GetComponent<PlayerStats>();
        fixedUpdateEnebled = false;
        lightUpCon.lightUps.Add(this.gameObject);
    }


    public void onImpusleActive()
    {
        if (Stats.waveRange >= Vector3.Distance(Player.transform.position, transform.position))
        {
            fixedUpdateEnebled = true;
        }
    }

    IEnumerator IWisiable()
    {
        if (duration <= Stats.waveDelay)
        {
            duration += Time.fixedDeltaTime;
            wow.SetActive(true);
            Debug.Log("tu jest ładny shader");
            yield return null;
        }
    }

    private void FixedUpdate()
    {
        if (fixedUpdateEnebled)
        {
            StartCoroutine(IWisiable());
            if (duration > Stats.waveDelay)
            {
                wow.SetActive(false);
                duration = 0;
                fixedUpdateEnebled = false;
            }
        }
    }
}
