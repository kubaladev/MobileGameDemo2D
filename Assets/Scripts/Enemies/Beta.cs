using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beta : Alpha
{
    [SerializeField] float sideMoveSpeed = 0.01f;
    int sideMoveDirection;
    [SerializeField] float sideMoveInterval = 2f;
    [SerializeField] Bullet storedBullet;
    [SerializeField] Transform gun;
    [SerializeField] float gunCooldown;

    private void Start()
    {
        sideMoveDirection = transform.position.x < 0 ? 1 : -1;
        StartCoroutine(ChangeDirection());
        StartCoroutine(Gun());
    }
    IEnumerator ChangeDirection()
    {
        while (sideMoveInterval > 0 )
        {
            yield return new WaitForSeconds(sideMoveInterval);
            sideMoveDirection *= -1;
        }

    }
    protected override void Move()
    {
        base.Move();
        transform.position += Vector3.right * sideMoveDirection * sideMoveSpeed;
    }
    IEnumerator Gun()
    {
        while (gunCooldown > 0)
        {
            float currentCooldown = gunCooldown + Random.Range(-0.25f * gunCooldown, 0.25f * gunCooldown);
            yield return new WaitForSeconds(currentCooldown);
            Shoot();
        }
    }

    public void Shoot()
    {
        Bullet flyingBullet = Instantiate(storedBullet);
        flyingBullet.transform.position = gun.position;
        flyingBullet.SetOwner(this.gameObject);
    }
}
