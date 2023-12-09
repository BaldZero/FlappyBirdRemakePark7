using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    private BoxCollider2D GroundCollide;
    private float groundHorizontalLenght;
    // Start is called before the first frame update
    void Start()
    {
        GroundCollide = GetComponent<BoxCollider2D>();
        groundHorizontalLenght = GroundCollide.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -groundHorizontalLenght)
        {
            RepositionBackGround();
        }
    }
    void RepositionBackGround()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLenght * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
