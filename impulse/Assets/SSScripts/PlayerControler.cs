using System.Collections;
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
    bool firstimpulse=false;
    public bool readyForNps=false;
    public GameObject Tutorial_one;

    float WaveDelay = 0.25f;
    float startWaveDelay=2;

    public float timer = 200;
    public Text timerText;
    public GameObject losePanel;
    public Text text;
    public GameObject menuPanel;
    public ExitZone exitZone;
    void Start()
    {
        Time.timeScale = 0;
        rb = GetComponent<Rigidbody>();
        hpBar.fillAmount = hp / 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateTimer();

        movement();

        sendImpuls();

        if (Input.GetKeyDown(KeyCode.E)||Input.GetButtonDown("Fire1"))
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
        else if (playerMat.color == Color.red||playerMat.color==Color.green)
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
        if (WaveDelay<=0)
        {
            Instantiate(circle, transform.position, Quaternion.identity);
            lightUpCon.showLights();
            firstimpulse = true;
            WaveDelay = startWaveDelay;
        }
        else
        {
            WaveDelay -= Time.fixedDeltaTime;
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
            if (hp<=0)
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
        losePanel.SetActive(true);
      
    }
    
    void updateTimer()
    {
        timer -= Time.fixedDeltaTime;
        timerText.text = ("Pozostało "+(int)timer +" secund");
        if (timer<197)
        {
            Tutorial_one.SetActive(false);
        }
        else if (timer<0)
        {
            endGame();
        }
    }
    public void startGame()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1;
        text.text = ("Udało ci się uratować" + exitZone.nextSpot+ "/3 zakładników.");
    }
}
