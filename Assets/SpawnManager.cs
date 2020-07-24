using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _TilePrefab;
    private Vector3 _spawnPos;
    private
    // Start is called before the first frame update
    void Start()
    {
        _spawnPos.z += 30;
        StartCoroutine(SpawnTileRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTileRoutine(){
        yield return new WaitForSeconds(0.5f);
        Instantiate(_TilePrefab, _spawnPos, _TilePrefab.transform.rotation);
        _spawnPos.z+=6;
        StartCoroutine(SpawnTileRoutine());
    }
}
