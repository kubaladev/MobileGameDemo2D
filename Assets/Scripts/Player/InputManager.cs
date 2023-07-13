using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] ButtonBasedInput buttonBasedInput;
    [SerializeField] AccelerometerBasedInput accelerometerBasedInput;
    public IInputStrategy GetSelectedStrategy()
    {
        if (SystemInfo.supportsAccelerometer)
        {
            Debug.Log("Accelerometer is supported.");
            return accelerometerBasedInput;
        }
        Debug.Log("Accelerometer is not supported.");
        return buttonBasedInput;
    }

}
