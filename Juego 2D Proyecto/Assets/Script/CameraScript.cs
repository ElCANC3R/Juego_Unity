using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject David;
    void Update()
    {
        Vector3 position = transform.position;
        position.x= David.transform.position.x;
        transform.position=position;
    }
}
