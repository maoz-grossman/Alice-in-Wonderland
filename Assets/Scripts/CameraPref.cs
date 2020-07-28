using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPref : MonoBehaviour
{
    [SerializeField]
    private Transform LookAt;
    [SerializeField]
    private Vector3 offset= new Vector3(0, 5.0f, -3f);
    // Start is called before the first frame update
   // void Start()
   // {
    //    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
   // }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPostion = LookAt.position + offset;
        desiredPostion.x = 0;
        transform.position = LookAt.position + offset;
    }
}
