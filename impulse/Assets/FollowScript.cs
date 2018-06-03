using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    Vector3 offSet;
    public Transform target;

    // Use this for initialization
    void Start()
    {
        offSet = this.transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position =offSet+ target.transform.position;
    }
}
