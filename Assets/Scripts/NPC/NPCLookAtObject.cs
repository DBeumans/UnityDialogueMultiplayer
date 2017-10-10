using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLookAtObject : MonoBehaviour {

    public void LookAtObject(GameObject obj)
    {
        if (obj == null)
            return;

        Vector3 lookdestination = new Vector3(obj.gameObject.transform.position.x, this.gameObject.transform.position.y, obj.gameObject.transform.position.z);

        this.gameObject.transform.LookAt(lookdestination);
    }

    public void LookAtVector(Vector3 objVector, float rotationSpeed)
    {
        var rotation = Quaternion.Euler(objVector);

        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
