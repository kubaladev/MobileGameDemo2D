using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            IWeapon incomingHit = collision.GetComponent<IWeapon>();
            if (incomingHit != null)
            {
                TakeDamage(incomingHit.DealDamage());
            }
        }
        
    }
}
