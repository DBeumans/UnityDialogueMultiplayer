using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : MonoBehaviour {

    /// <summary>
    /// Check the distance between object A and object B. 
    /// This function also takes a max distance to check if the objects are within the max distance.
    /// </summary>
    /// <param name="obj_1"></param>
    /// <param name="obj_2"></param>
    /// <param name="max_distance"></param>
    /// <returns></returns>
    public static bool CheckRangeBetweenObjects(Transform obj_1, Transform obj_2, float max_distance)
    {
        float dist;

        dist = Vector3.Distance(obj_1.position, obj_2.position);

        if (dist <= max_distance) // is in range.
            return true;

        return false;
    }
}
