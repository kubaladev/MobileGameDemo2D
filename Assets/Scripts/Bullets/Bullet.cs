using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IWeapon
{

    [SerializeField] protected float speed = 0.1f;
    [SerializeField] protected Vector2 direction = Vector2.down;
    [SerializeField] protected int damage = 1;
    
    SpriteRenderer spriteRenderer;
    float outOfBoundsTime = 0f;
    GameObject owner;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetOwner(GameObject owner)
    {
        this.owner = owner;
    }
    void OutOfBoundsCheck()
    {
        if (!spriteRenderer.isVisible)
        {
            outOfBoundsTime += Time.deltaTime;
            if (outOfBoundsTime > 0.2f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBoundsCheck();
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(direction.x,direction.y)* speed;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteor"))
        {
            Destroy(this.gameObject);
        }
    }

    public int DealDamage()
    {
        Destroy(this.gameObject);
        return damage;
    }

    public GameObject GetOwner()
    {
        return owner;
    }
}
