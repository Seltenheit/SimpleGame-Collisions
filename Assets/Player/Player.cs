using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public float speed = 6;
    int coinCounter;
    Rigidbody rigidbody;
    Vector3 velocity;

    public event Action OnPlayerDeath;
    public float health = 10;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        velocity = direction * speed;

        if (health <= 0)
        {
            //PlayerScript playerScript = FindObjectOfType<PlayerScript>();
            //playerScript.GameOver();
            if (OnPlayerDeath != null)
                OnPlayerDeath();
            Destroy(gameObject);

        }

    }

    private void FixedUpdate()
    {
        rigidbody.position += velocity * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider triggerCollider)
    {
        print(triggerCollider.gameObject.name);
        if (triggerCollider.tag == "Coin")
        {
            Destroy(triggerCollider.gameObject);
            coinCounter++;
        }
    }
}
