﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [Tooltip("How much force knocks the player backwards after crashing into an obstacle.")]
    public float knockbackForce;

    [Tooltip("How many seconds before the player can move downhill again after crashing into an obstacle.")]
    public float recoveryTime;

    [Tooltip("Checks when the player is hurt.")]
    public bool hurt = false;

    private Rigidbody rb;


    //Register that TakeDamage will be called when an OnPlayerHit Event happens
    private void OnEnable()
    {
        PlayerEvent.OnPlayerHit += TakeDamage;
    }

    //Un Register TakeDamade will be called when an OnPlayerHit Event happens

    private void OnDisable()
    {
        PlayerEvent.OnPlayerHit -= TakeDamage;
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void TakeDamage()
    {
        if (hurt == false)
        {
            hurt = true;
            rb.velocity = Vector3.zero;
            // sends the player up and back from bumping into an obstacle
            rb.AddForce(transform.forward * -knockbackForce);
            rb.AddForce(transform.up * 500);
            StartCoroutine("Recover");
        }
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(recoveryTime);
        hurt = false;
    }
}
