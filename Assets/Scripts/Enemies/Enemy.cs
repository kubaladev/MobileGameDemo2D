 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnEnemyEscaped;
    public event Action<Enemy> OnEnemyKilled;
    [SerializeField] protected float speed = 0.1f;
    [SerializeField] protected int health = 3;
    public int score = 100;
    protected SpriteRenderer spriteRenderer;
    float escapeYpoint;

    Camera cam;
    protected bool escaped = false;

    protected virtual void Awake()
    {
        cam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected virtual void FixedUpdate()
    {
        Move();
        CheckEscape();
    }

    protected virtual void Move()
    {
        transform.position += Vector3.down * speed;
    }
    protected void Escape()
    {
        escaped = true;
        OnEnemyEscaped?.Invoke(this);
        Destroy(this.gameObject, 0.5f);
    }
    protected void CheckEscape()
    {
        if (escaped) return;
        Vector3 pos = cam.WorldToScreenPoint(transform.position);
        if(pos.y < Screen.safeArea.yMin - 0.05f)
        {
            Escape();
        }
    }
    protected virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnEnemyKilled?.Invoke(this);
            Destroy(this.gameObject);
        }
        else
        {
            StartCoroutine(HitAnimation());
        }

    }
    protected IEnumerator HitAnimation()
    {
        Color defColor = spriteRenderer.color;
        spriteRenderer.color = Color.clear;
        yield return new WaitForSeconds(0.12f);
        spriteRenderer.color = defColor;
    }

}
