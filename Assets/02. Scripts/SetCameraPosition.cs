using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraPosition : MonoBehaviour
{
    public Transform player;
    public Vector3 addPos;

    void Update()
    {
        transform.position = player.position + addPos;
    }
}
