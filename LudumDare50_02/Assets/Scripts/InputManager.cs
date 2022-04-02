using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    [SerializeField] Controls controls;

    private void Awake()
    {
        AssignSingleton();
    }
    private void Start()
    {
        AssignInputTriggers();
    }
    void AssignSingleton()
    {
#if UNITY_EDITOR
        if (instance != null)
        {
            Debug.LogWarning("You have more than one InputManager in scene");
        }
#endif
    }
    void AssignInputTriggers()
    {
        controls.MovementPrompts.Left.performed =+ context => StepLeft();
        controls.MovementPrompts.Right.performed =+ context => StepRight();
        controls.MovementPrompts.Jump.performed =+ context => Jump();
        controls.MovementPrompts.Duck.performed =+ context => Duck();
    }
    void StepLeft()
    {

    }
    void StepRight()
    {

    }
    void Jump()
    {

    }
    void Duck()
    {

    }
}
