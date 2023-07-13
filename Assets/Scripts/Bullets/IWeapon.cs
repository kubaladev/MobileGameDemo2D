using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public int DealDamage();
    public GameObject GetOwner();
    public void SetOwner(GameObject owner);
}
