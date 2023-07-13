using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float shrinkValue = 0.5f;
    void SlowlyRotate()
    {
        transform.eulerAngles = transform.eulerAngles + Vector3.forward * rotationSpeed; 
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        SlowlyRotate();
    }
    private void Start()
    {
        int size = Random.Range(3, 6);
        health = size;
        transform.localScale = Vector3.one + Vector3.one * size *shrinkValue;
    }
    private void ShrikOnDamage()
    {
        transform.localScale = transform.localScale - Vector3.one * shrinkValue;
    }
    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        ShrikOnDamage();
    }
    private void OnMouseDown()
    {
        TakeDamage(1);
    }
}
