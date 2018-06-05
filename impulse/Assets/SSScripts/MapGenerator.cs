﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Texture2D map;
    public GameObject wall;
    public GameObject Spike;
    public GameObject player;
    public LightUpControler lightUpCon;
    public Transform camera;
    GameObject temp;
    // Use this for initialization
    void Start()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                Color color = map.GetPixel(x, y);
                if (color == Color.black)
                {
                    temp = Instantiate(wall, new Vector3(x, 0.5f, y), Quaternion.identity);
                }
                else if (color==Color.red)
                {
                    temp = Instantiate(Spike, new Vector3(x, 0.5f, y), Quaternion.identity);
                }
                else if (color==Color.green)
                {
                    movePlayer(new Vector3(x, 1f, y));
                }
                if (temp!=null)
                {
                temp.GetComponent<LightUp>().Player = player;
                temp.GetComponent<LightUp>().lightUpCon = lightUpCon;
                    temp = null;                }

            }
        }
    }

void movePlayer(Vector3 pos)
    {
        Vector3 offSet= camera.position - player.transform.position;
        player.transform.position = pos;
        camera.position = offSet + player.transform.position;
    }
}
