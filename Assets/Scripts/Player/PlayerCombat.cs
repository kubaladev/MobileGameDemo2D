using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float fireCooldown = 0.4f;
    bool isShootingOn = true;
    public UnityEvent OnPlayerKilled;
    private void Start()
    {
        StartCoroutine(AutoShooting());
    }

    void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.GetComponent<IWeapon>().SetOwner(this.gameObject);
        spawnedBullet.transform.position = gun.position;
    }
    IEnumerator AutoShooting()
    {
        while (isShootingOn)
        {
            yield return new WaitForSeconds(fireCooldown);
            Fire();
        }

    }
    void Die()
    {
        OnPlayerKilled?.Invoke();
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Meteor"))
        {
            Die();
        }
        if (collision.CompareTag("Bullet"))
        {
            IWeapon weapon = collision.GetComponent<IWeapon>();
            if(weapon.GetOwner()!= this.gameObject)
            {
                Die();
            }
        }
    }
}
