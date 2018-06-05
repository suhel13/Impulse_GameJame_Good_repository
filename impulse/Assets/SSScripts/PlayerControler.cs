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
    float takingDamageDelay = 0;
    int hp = 3;
    public Image hpBar;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hpBar.fillAmount = hp / 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();

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

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(circle, transform.position, Quaternion.identity);
            lightUpCon.showLights();
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
                playerIsDead();
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

    void playerIsDead()
    {

    }
}
