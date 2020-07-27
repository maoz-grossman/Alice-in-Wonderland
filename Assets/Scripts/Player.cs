using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coins = 0;
    private int _size = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin()
    {
        _coins++;
    }

    public void setGrow()
    {
        if (_size < 14) {

            if(_size >= 7)
                transform.localScale += new Vector3(.2f, .2f, .2f);


            else
                transform.localScale += new Vector3(.1f, .1f, .1f);

            _size++;
        }
    }

    public void setShort()
    {
        if (_size > 0)
        {
            if (_size > 7)
                transform.localScale -= new Vector3(.2f, .2f, .2f);
            
            else
                transform.localScale -= new Vector3(.1f, .1f, .1f);

            _size--;
        }
    }
}
