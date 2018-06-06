using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExpensions
{
    public static Vector3 Pozyjca (this GameObject gameObject)
    {
        return gameObject.transform.position;
    }
}
