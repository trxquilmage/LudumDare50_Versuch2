using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackManager : MonoBehaviour
{
    public static FeedbackManager instance;
    [SerializeField] GameObject feebackImagePrefab;
    [SerializeField] GameObject canvas;

    Dictionary<Step, GameObject> stepFeedback = new Dictionary<Step, GameObject>();
    Dictionary<InputManager.Inputs, bool> currentPossibleKeys = new Dictionary<InputManager.Inputs, bool>();
    InputManager.Inputs keyLastRound = InputManager.Inputs.Jump;

    Step currentStep;

    bool stillNeedsFeedback = true;
    bool firstRound = true;
    public bool startFeedback;

    int[] feedbackCounters = new int[4];
    private void Awake()
    {
        AssignSingleton();
        for (int i = 0; i < 4; i++)
            currentPossibleKeys.Add((InputManager.Inputs)i, (i == 0));
    }
    private void Update()
    {
        if (!startFeedback)
            return;

        if (firstRound)
        {
            InstantiateFeedbackUnderneathEachStep();
            firstRound = false;
            StartCoroutine(TurnFeedbackoffAfterSeconds(60));
        }
        if (stillNeedsFeedback)
            UpdateEachStepMovement();
    }
    void AssignSingleton()
    {
#if UNITY_EDITOR
        if (instance != null)
        {
            Debug.LogWarning("You have more than one InputManager in scene");
        }
#endif
        instance = this;
    }
    public void DealWithFeedback(InputManager.Inputs inputs)
    {
        Debug.Log(currentStep.input+ " " + inputs);
        if (!CheckIfInputWasCorrect(inputs))
        {
            return;
        }
        stepFeedback[currentStep].GetComponent<FeedbackImage>().HighlightAndVanish();
    }
    public void SetCurrentStep(Step step)
    {
        currentStep = step;
    }
    public bool CheckIfInputWasCorrect(InputManager.Inputs inputs)
    {
        return inputs == currentStep.input;
    }
    public void SetFeedbackForStep(Step step)
    {
        ManagePossibleKeyList(step.input);
        int firstPossibleKey = (int)GetFirstPossibleKey();

        if (feedbackCounters[firstPossibleKey] > 2)
        {
            CheckIfAllFeedbacksAreDone();
            return;
        }
        if (CheckIfStepIsInTheLowerHalf(step))
        {
            stepFeedback[step].GetComponent<Image>().color =
                new Color(1, 1, 1, 0);
            return;
        }

        SignalStepBeat(step, firstPossibleKey);
        stepFeedback[step].GetComponent<Image>().color =
                new Color(1, 1, 1, 1);
    }
    void InstantiateFeedbackUnderneathEachStep()
    {
        foreach (Step step in Stepmanager.Instance.steps)
        {
            stepFeedback.Add(step, Instantiate(feebackImagePrefab, canvas.transform));
            SetFeedbackForStep(step);
        }
        UpdateEachStepMovement();
    }
    void UpdateEachStepMovement()
    {
        foreach (Step step in Stepmanager.Instance.steps)
            MoveStep(step);
    }
    void MoveStep(Step step)
    {
        Vector3 scaleVector = new Vector3(1, 1, 0);
        stepFeedback[step].transform.position = Camera.main.WorldToScreenPoint(step.transform.position);
        stepFeedback[step].transform.position.Scale(scaleVector);
        stepFeedback[step].transform.position += Vector3.down * 20;
    }
    bool CheckIfStepIsInTheLowerHalf(Step currentStep)
    {
        int i = 0;
        foreach (Step step in Stepmanager.Instance.steps)
        {
            if (currentStep == step)
                return i < Stepmanager.Instance.steps.Count / 2;
            i++;
        }
#if UNITY_EDITOR
        Debug.LogWarning("Waring: Found a step that doesnt Exist!");
#endif
        return false;
    }
    void SignalStepBeat(Step step, int firstPossibleKey)
    {
        feedbackCounters[firstPossibleKey]++;
        FeedbackImage img = stepFeedback[step].GetComponent<FeedbackImage>();
        img.SwitchImageAndBlendIn((InputManager.Inputs)firstPossibleKey);
    }
    void CheckIfAllFeedbacksAreDone()
    {
        for (int i = 0; i < 4; i++)
        {
            if (feedbackCounters[i] > 2)
            {
                if (i == 3)
                    stillNeedsFeedback = false;
                continue;
            }
            break;
        }
    }
    void ManagePossibleKeyList(InputManager.Inputs inputs)
    {
        if ((int)inputs < (int)InputManager.Inputs.Jump)
        {
            if ((int)keyLastRound > (int)InputManager.Inputs.Right)
            {
                currentPossibleKeys[InputManager.Inputs.Left] = true;
                currentPossibleKeys[InputManager.Inputs.Right] = true;
            }
            else
            {
                currentPossibleKeys[InputManager.Inputs.Left] = keyLastRound != InputManager.Inputs.Left;
                currentPossibleKeys[InputManager.Inputs.Right] = keyLastRound != InputManager.Inputs.Right;
            }
            currentPossibleKeys[InputManager.Inputs.Jump] = false;
            currentPossibleKeys[InputManager.Inputs.Duck] = false;
        }
        else if ((int)inputs == (int)InputManager.Inputs.Jump)
        {
            currentPossibleKeys[InputManager.Inputs.Left] = false;
            currentPossibleKeys[InputManager.Inputs.Right] = false;
            currentPossibleKeys[InputManager.Inputs.Jump] = true;
            currentPossibleKeys[InputManager.Inputs.Duck] = false;
        }
        else if ((int)inputs == (int)InputManager.Inputs.Duck)
        {
            currentPossibleKeys[InputManager.Inputs.Left] = false;
            currentPossibleKeys[InputManager.Inputs.Right] = false;
            currentPossibleKeys[InputManager.Inputs.Jump] = false;
            currentPossibleKeys[InputManager.Inputs.Duck] = true;
        }

        keyLastRound = GetFirstPossibleKey();
    }
    public InputManager.Inputs GetFirstPossibleKey()
    {
        for (int i = 0; i < 4; i++)
            if (currentPossibleKeys[(InputManager.Inputs)i])
                return (InputManager.Inputs)i;
#if UNITY_EDITOR
        Debug.LogWarning("Waring: There was no Key found here!");
#endif
        return InputManager.Inputs.Left;
    }
    IEnumerator TurnFeedbackoffAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        stillNeedsFeedback = false;
        foreach (Step step in Stepmanager.Instance.steps)
            stepFeedback[step].GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }
}
