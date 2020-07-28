using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPref : MonoBehaviour
{
    [SerializeField]
    private Transform LookAt;
    [SerializeField]
    private Vector3 offset= new Vector3(0, 5.0f, -3f);
    
    void LateUpdate()
    {
        Vector3 desiredPostion = LookAt.position + offset;
        desiredPostion.x = 1.76f;
        transform.position = desiredPostion;
    }
}
