using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TileBehavior Tiles = other.GetComponent<TileBehavior>();
            Player player = other.GetComponent<Player>();
            PlayerMotor playerm = other.GetComponent<PlayerMotor>();
            int size = (int)Tiles.randoms.Dequeue();
            int playersize = player._size;
            if ((6 + size) > player._size)
                playerm.dead = true;
        }
    }
}
