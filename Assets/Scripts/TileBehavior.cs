﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * player: 0. singleton. 
           1.Movement:
           2.Items:  
powerUps: _1. scaleup 
	    2. scaleDown
 	   3. coins
	   4.fruit(optional)
obstical: 
area:
spawner: _powerUp.
   	_obstical.
  	_tiles.
             */
public class TileBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _TilePrefab;
    private Vector3 _spawnPos;
    public float Player_speed=3f;
    private CharacterController _controller;
    private float _gravity = 9.807f;
    [SerializeField]
    private Transform trr;
    [SerializeField]
    private float _scaleUp = 1;
    [SerializeField]
    private float _scaleDown =1;
    private int _round = 1;

    [SerializeField]
    private GameObject[] _obstacles;

    void Start()
    {
        _spawnPos.z += 120;
        _controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Movement();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tile")
        {
            Debug.Log("Hey");
            Destroy(other.transform.parent.gameObject, 1.5f);
        }
        else if(other.tag == "Arc")
        {
            Destroy(other.gameObject, 0.2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tile"|| other.tag == "Arc")
        {
            if (_round % 3 != 0)
            {
                Debug.Log("ooouch");
                GameObject temp= Instantiate(_TilePrefab, _spawnPos, _TilePrefab.transform.rotation);
                _spawnPos.z += 30;
                _spawnPos.x = temp.transform.position.x;
                _spawnPos.y = temp.transform.position.y;
            }
            else
            {
                int randomX = Random.Range(0, _obstacles.Length);
                float rand_size = Random.Range(.1f, .5f);
                if (randomX == 0)
                {
                    float diff1 = (0.275f * ((rand_size * 10f) - 3f));
                    float diff2 = (0.15f * ((rand_size * 10f) - 3f));
                    Vector3 newpos = new Vector3(1.3f + diff1 , -2.2f + diff2, _spawnPos.z);
                    GameObject obstacle = Instantiate(_obstacles[randomX], newpos, _obstacles[randomX].transform.rotation);
                    obstacle.transform.localScale *= rand_size;
                }
            }
            _round++;
        }
    }

    private void Movement()
    {
        bool flag = false;
        Vector3 direction = new Vector3(0, 0, 1);
        Vector3 velocity = direction * Player_speed;

        if (!_controller.isGrounded)
        {
            velocity.y -= _gravity;
        }
        float x = 0f;
        if (Input.GetKeyDown(KeyCode.A) &&transform.position.x>-3.63f)
        {
            flag = true;
            x= -4f;
        }

        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 4.36f)
        {
            flag = true;
            x= 4f;
        }

        if(!flag)
        _controller.Move(velocity * Time.deltaTime);
        else
        _controller.Move(new Vector3(x,0,10*Time.deltaTime));
    }
}
