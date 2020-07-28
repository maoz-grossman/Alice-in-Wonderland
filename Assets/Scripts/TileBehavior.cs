using System.Collections;
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

    public Queue randoms = new Queue();
    private Animator _anim;
    void Start()
    {
        _spawnPos.z += 150;
        _spawnPos.y += 17.254f;
        _spawnPos.x += 5.896f;
        _anim = GetComponent<Animator>();

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tile")
        {
            MakeTile();
        }
        else if(other.tag == "Arc")
        {
            MakeTile();
        }
        else if (other.tag == "End")
        {
            Destroy(other.transform.parent.parent.gameObject, 0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Arc")
        Destroy(other.gameObject, 0.2f);
    }
 
    private void MakeTile()
    {
        int randomX = Random.Range(0, _obstacles.Length);
        if (!(_round % 3 == 0 && randomX != 0))
        {
            GameObject temp = Instantiate(_TilePrefab, _spawnPos, _TilePrefab.transform.rotation);
            _spawnPos.z += 60;
            _spawnPos.x = temp.transform.position.x;
            _spawnPos.y = temp.transform.position.y;
        }
        if (_round % 3 == 0)
        {
            if (randomX == 0)
            {
                float rand_size = Random.Range(.3f, .5f);
                randoms.Enqueue((int)rand_size);
                if (randomX == 0)
                {
                    float diff1 = (0.275f * ((rand_size * 10f) - 3f));
                    float diff2 = (0.15f * ((rand_size * 10f) - 3f));
                    Vector3 newpos = new Vector3(2.6323f + diff1, 0.55271f + diff2, _spawnPos.z);
                    GameObject obstacle = Instantiate(_obstacles[randomX], newpos, _obstacles[randomX].transform.rotation);
                    obstacle.transform.localScale *= rand_size;
                }
            }

            else
            {
                if (randomX == 1)
                {
                    Instantiate(_obstacles[randomX], _spawnPos, _obstacles[randomX].transform.rotation);
                    int i = Random.Range(1, 5);
                    randoms.Enqueue(i);
                    _spawnPos.z += (2.5f * i);
                }
                else
                {

                }
            }

        }
        _round++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Arc")
        {
            PlayerMotor player = GetComponent<PlayerMotor>();
            player.dead = true;
            _anim.SetBool("Dead", true);
        }
    }

}
