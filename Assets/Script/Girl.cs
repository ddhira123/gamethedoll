﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    public float upForce;
    private Animator anim;
    private bool isDead = false;            //Has the player collided with a wall?
    private Rigidbody2D rb2d;                //Holds a reference to the Rigidbody2D component of the bird.
    public bool slash = false;
    public float fallMultiplier = 2.5f;
    private float startPos;
    SoundManager S;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
		startPos = rb2d.position.x;
        S = GameObject.FindObjectOfType(typeof(SoundManager)) as SoundManager;
    }

    void Update()
    {
        //Don't allow control if the bird has died.
        if (isDead == false)
        {   
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            if(GameControl.instance.score % 5 == 0 || rb2d.position.x < startPos){
                rb2d.velocity = new Vector2(0.5f, rb2d.velocity.y);
            }
            if (Input.GetMouseButtonDown(0) && rb2d.velocity.x == 0f)
            {
                anim.SetTrigger("Girl_Jump");
                S.PlaySound(1);
                rb2d.velocity = (new Vector2(rb2d.velocity.x, upForce));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Girl_Slashing");
                S.PlaySound(2);
                GameControl.instance.girlBehave = 2;
				slash = true;
			}
        }
    }

    void OnCollisionEnter2D(Collision2D trig)
    {       
        if(trig.gameObject.CompareTag("human"))
        {
            if(slash == true){
                Destroy(trig.gameObject);
                GameControl.instance.GirlScored();
                slash = false;
            }
            else {
                GirlDie();
            }
        }
    }

    public void GirlDie(){
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Girl_Die");
        GameControl.instance.GirlDied();
    }
}
