using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 _spawnPos;
    public static bool isSpawn = true;
    private bool go = false;
    private int _round = 1;
    [SerializeField]
    private GameObject [] _obstacles;
    // Start is called before the first frame update
    void Start()
    {
        _spawnPos.z += 20;

        if(isSpawn)
        StartCoroutine(SpawnRoutine());
        else
            go = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            go = false;
            StartCoroutine(SpawnRoutine());
        }
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(0.05f);
        int randomX = Random.Range(0, 3);
        int randomside= Random.Range(-1, 2);
        Vector3 newpos = new Vector3(1.8f+(((randomside)*3)*1.3f), 1f, _spawnPos.z);
        if (_round % 7 == 0)
        {
            randomX = Random.Range(3, _obstacles.Length);
                newpos.y = 0;
        }

        if (randomX == 0)
        {
            randomside = Random.Range(1, 6);
            newpos.y = randomside;
        }
        if ((int)(newpos.z) % 10 == 0 && randomX > 2)
            newpos.z += 5;

        GameObject obstacle = Instantiate(_obstacles[randomX], newpos, _obstacles[randomX].transform.rotation);
        _spawnPos.z += 3;
        _round++;

        if (isSpawn)
            StartCoroutine(SpawnRoutine());
        else
            go = true;
    }
}
