using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Attack
{
    [SerializeField]
    float speed;
    [HideInInspector]
    public Vector3 direction;
    [SerializeField]
    float duration;
    [SerializeField]
    int damage;
    private void Start()
    {
        Destroy(gameObject, duration);
    }
    public override int OnHit()
    {
        Destroy(gameObject);
        return damage;

    }
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
