using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerBasedInput : MonoBehaviour, IInputStrategy
{
    public float GetMovementInput()
    {
        Vector3 tilt = Input.acceleration;
        return tilt.x;
    }
}
