using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    
    public float Player_speed=3f;
    private CharacterController _controller;
    private float _gravity = 9.807f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tile")
        {
            Debug.Log("Hey");
            Destroy(other.gameObject, 1f);
        }
    }

    private void Movement()
    {
        Vector3 direction = new Vector3(0, 0, 1);
        Vector3 velocity = direction * Player_speed;

        if (!_controller.isGrounded)
        {
            velocity.y -= _gravity;
        }
        
        _controller.Move(velocity * Time.deltaTime);
    }
}
