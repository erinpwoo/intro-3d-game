﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public float duration = 2f;
    private float lifeTimer;

    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = duration;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().health -= 5;
            if (collision.gameObject.GetComponent<Player>().health <= 0) {
                CancelInvoke();
                collision.gameObject.GetComponent<Player>().GameOver();
            }
        }
    }
}
