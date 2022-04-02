using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    [SerializeField] bool usesLeftAndRight = true;

    public enum Inputs
    {
        Left, Right, Jump, Duck
    }
    float[] lastInputTime = new float[4];
    bool lastStepWasWrong;

    Controls controls;
    Dictionary<Inputs, bool> currentPossibleKeys = new Dictionary<Inputs, bool>();
    Inputs lastPressedKey;

    public void SignalNextBeat(Inputs inputs)
    {
        if (usesLeftAndRight)
            ManagePossibleKeyList();
        PortrayFeedback(inputs);
    }

    void Awake()
    {
        AssignSingleton();
    }
    void Start()
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
        controls = new Controls();
        controls.Enable();
        controls.MovementPrompts.Left.performed += context => StepLeft();
        controls.MovementPrompts.Right.performed += context => StepRight();
        controls.MovementPrompts.Jump.performed += context => Jump();
        controls.MovementPrompts.Duck.performed += context => Duck();
    }
    void AssignValues()
    {
        currentPossibleKeys[Inputs.Duck] = true;
        currentPossibleKeys[Inputs.Jump] = true;
    }
    void StepLeft()
    {
        SetLastPressed(Inputs.Left);
        if (PressedCorrectKey(Inputs.Left))
            CompareToBeatTime(Inputs.Left);
        Debug.Log(lastInputTime[(int)Inputs.Left]);
    }
    void StepRight()
    {
        SetLastPressed(Inputs.Right);
        if (PressedCorrectKey(Inputs.Right))
            CompareToBeatTime(Inputs.Right);
        Debug.Log(lastInputTime[(int)Inputs.Right]);
    }
    void Jump()
    {
        SetLastPressed(Inputs.Jump);
        if (PressedCorrectKey(Inputs.Jump))
            CompareToBeatTime(Inputs.Jump);
        Debug.Log(lastInputTime[(int)Inputs.Jump]);
    }
    void Duck()
    {
        CompareToBeatTime(Inputs.Duck);
        Debug.Log(lastInputTime[3]);
    }
    void CompareToBeatTime(Inputs inputs)
    {
        //if (BeatManager.instance.IsOnBeat())
            //Debug.Log("Correct Key -> Is On Beat!");
            //Player.ContinueWalking();
    }
    bool PressedCorrectKey(Inputs inputs)
    {
        return currentPossibleKeys[inputs];
    }
    void SetLastPressed(Inputs lastInput)
    {
        lastPressedKey = lastInput;
    }
    void ManagePossibleKeyList()
    {
        if (lastPressedKey == Inputs.Jump || lastStepWasWrong)
        {
            currentPossibleKeys[Inputs.Left] = true;
            currentPossibleKeys[Inputs.Right] = true;
        }
        else
        {
            currentPossibleKeys[Inputs.Left] = lastPressedKey != Inputs.Left;
            currentPossibleKeys[Inputs.Right] = lastPressedKey != Inputs.Right;
        }
    }
    void PortrayFeedback(Inputs inputs)
    {
        
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}