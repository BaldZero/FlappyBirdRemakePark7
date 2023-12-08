using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerBowler : MonoBehaviour
{
    private Rigidbody2D r2d2;
    // Start is called before the first frame update
    void Start()
    {
        r2d2 = GetComponent<Rigidbody2D>();
        r2d2.velocity = new Vector2(ControllGame.instance.scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(ControllGame.instance.GameOver == true)
        {
            r2d2.velocity = Vector2.zero;
        }
    }
}
