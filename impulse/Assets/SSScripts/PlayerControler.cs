﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControler : MonoBehaviour
{
    Rigidbody rb;
    [Range(5f, 15f)] public float speed;
    Vector3 axis;
    public LightUpControler lightUpCon;
    public GameObject circle;
    public Material playerMat;


    float maxtakingDamageDelay = 1f;
    float takingDamageDelay = 0f;
    int hp = 3;
    public Image hpBar;
    bool firstimpulse = false;
    public bool readyForNps = false;
    public GameObject Tutorial_one;

    float WaveDelay = 0f;
    float startWaveDelay = 1.5f;

    public float timer = 200;
    public Text timerText;

    public Image Batery;
    public UIControler uIControler;
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        hpBar.fillAmount = hp / 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (firstimpulse)
        {
            movement();
            updateTimer();
        }

        sendImpuls();

        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire1"))
        {
            readyForNps = true;
        }
        else
        {
            readyForNps = false;
        }

        if (takingDamageDelay > 0)
        {
            takingDamageDelay -= Time.fixedDeltaTime;
        }
        else if (playerMat.color == Color.red || playerMat.color == Color.green)
        {
            playerMat.color = Color.white;
        }

    }

    private void movement()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.z = Input.GetAxis("Vertical");
        if (axis.magnitude > 1)
        {
            axis.Normalize();

        }

        rb.velocity = axis * speed;
    }

    private void sendImpuls()
    {
        if (WaveDelay >= startWaveDelay && Input.GetButtonDown("Jump"))
        {
            Instantiate(circle, transform.position, Quaternion.identity);
            lightUpCon.showLights();
            firstimpulse = true;
            WaveDelay = 0;
            Tutorial_one.SetActive(false);
        }
        else
        {
            WaveDelay += Time.fixedDeltaTime;
            Batery.fillAmount = WaveDelay/ startWaveDelay;
        }
    }

    public void takeDamage(int damage)
    {
        if (takingDamageDelay <= 0)
        {
            hp -= damage;
            takingDamageDelay = maxtakingDamageDelay;
            playerMat.color = Color.red;
            hpBar.fillAmount = hp / 5f;
            if (hp <= 0)
            {
                endGame();
            }
        }
    }

    public bool takeHeal(int heal)
    {

        if (hp <= 4)
        {
            hp += heal;
            takingDamageDelay = maxtakingDamageDelay;
            playerMat.color = Color.green;
            hpBar.fillAmount = hp / 5f;
            return true;
        }
        else
            return false;

    }

    void endGame()
    {
        Debug.Log("przegrałeś");
        uIControler.activeLosePanel();
    }

    void updateTimer()
    {
        timer -= Time.fixedDeltaTime;
        timerText.text = ((int)timer + " sekund");
        if (timer < 0)
        {
            endGame();
        }
    }

}
