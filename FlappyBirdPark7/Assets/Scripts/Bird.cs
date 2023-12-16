using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float FlyForce = 200f;
    public AudioClip FlapSound;
    public AudioClip DeadSound;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator animate;
    
    PolygonCollider2D poly;
    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        poly = GetComponent<PolygonCollider2D>();
        audiosource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.anyKeyDown)
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, FlyForce));
                animate.SetTrigger("Flap");
                PlaySound(FlapSound);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead == false)
        {
            PlaySound(DeadSound);
        }
        isDead = true;
        animate.SetTrigger("Dead");
        poly.offset = new Vector2(0, 0.1f);
        ControllGame.instance.BirdDead();
        rb2d.velocity = Vector2.zero;
        
    }




}
