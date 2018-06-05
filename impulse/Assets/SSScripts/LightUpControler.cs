using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpControler : MonoBehaviour
{
    public List<GameObject> lightUps = new List<GameObject>();
   

    public void showLights()
    {
        foreach (GameObject item in lightUps)
        {
            item.GetComponent<LightUp>().onImpusleActive();
        }
    }


}
