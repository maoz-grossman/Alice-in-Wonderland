using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Update values acordding to the recived PowerUp
*/
public class Player_PowerUps_Handler : MonoBehaviour
{
    [SerializeField]
    private Transform _tr;

    // Start is called before the first frame update
    void Start()
    {
        _tr = GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        //_tr.localScale += new Vector3(.01f, .01f, .01f);
    }
}
