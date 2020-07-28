using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPref : MonoBehaviour
{
    public static float X_pos = 0;
    public static float Y_pos = 0;
    public static float Z_pos = 1;
    public static bool follow_player = true;
    [SerializeField]
    private Transform LookAt;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 5.0f, -3f);

    // Start is called before the first frame update
    // void Start()
    // {
    //    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
    // }

    // Update is called once per frame
    void LateUpdate()
    {
        if (follow_player)
        {
            Vector3 desiredPostion = LookAt.position + offset;
            desiredPostion += new Vector3(0, Y_pos, 0);
            desiredPostion.z += Z_pos; 
            desiredPostion.x = 1.76f+ X_pos;
            transform.position = desiredPostion;
        }
    }
}
