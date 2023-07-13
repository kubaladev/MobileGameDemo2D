using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBasedInput : MonoBehaviour, IInputStrategy
{
    bool rightButtonPressed = false;
    bool leftButtonPressed = false;
    public void TriggerRightButton(bool stateOfActivation)
    {
        rightButtonPressed = stateOfActivation;
    }
    public void TriggerOnLeftButton(bool stateOfActivation)
    {
        leftButtonPressed = stateOfActivation;
    }
    public float GetMovementInput()
    {
        if (leftButtonPressed && rightButtonPressed) return 0;
        if (leftButtonPressed) return -1;
        if (rightButtonPressed) return 1;
        return 0;
    }
}
