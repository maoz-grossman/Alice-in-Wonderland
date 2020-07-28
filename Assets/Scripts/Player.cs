using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coins = 0;
    public int _size = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(int num)
    {
        _coins+=num;
    }

    public void setGrow()
    {
        if (_size < 10) {

            if(_size >= 7)
                transform.localScale += new Vector3(.5f, .5f, .5f);


            else
                transform.localScale += new Vector3(.8f, .8f, .8f);

            _size++;
        }
    }

    public void setShort()
    {
        if (_size > 2)
        {
            if (_size > 7)
                transform.localScale -= new Vector3(.5f, .5f, .5f);
            
            else
                transform.localScale -= new Vector3(0.8f, 0.8f, 0.8f);

            _size--;
        }
    }
}
