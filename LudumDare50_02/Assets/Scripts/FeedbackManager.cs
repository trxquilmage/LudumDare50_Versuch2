using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackManager : MonoBehaviour
{
    [SerializeField] GameObject feebackImagePrefab;
    [SerializeField] GameObject canvas;
    Dictionary<Step, GameObject> stepFeedback = new Dictionary<Step, GameObject>();
    bool stillNeedsFeedback = true;
    bool ab;
    public bool startFeedback;

    int[] feedbackCounters = new int[4];

    private void Update()
    {
        if (startFeedback)
        {
            if (!ab)
                InstantiateFeedbackUnderneathEachStep();
            ab = true;
            UpdateFeedbackUnderneathEachStep();
        }
    }
    public void InstantiateFeedbackUnderneathEachStep()
    {
        foreach (Step step in Stepmanager.Instance.steps)
        {
            stepFeedback.Add(step, Instantiate(feebackImagePrefab, canvas.transform));
        }
        UpdateFeedbackUnderneathEachStep();
    }
    public void UpdateFeedbackUnderneathEachStep()
    {
        if (!stillNeedsFeedback)
            return;
        Vector3 scaleVector = new Vector3(1, 1, 0);
        foreach (Step step in stepFeedback.Keys)
        {
            int firstPossibleKey = (int)InputManager.instance.GetFirstPossibleKey();
            if (feedbackCounters[firstPossibleKey] > 2)
            {
                CheckIfAllFeedbacksAreDone();
                continue;
            }

            if (CheckIfStepIsInTheLowerHalf(step))
            {
                stepFeedback[step].GetComponent<Image>().color =
                    new Color(1, 1, 1, 0);
                continue;
            }

            SignalStepBeat(step, firstPossibleKey);
            stepFeedback[step].GetComponent<Image>().color =
                    new Color(1, 1, 1, 1);
            stepFeedback[step].transform.position = Camera.main.WorldToScreenPoint(step.transform.position);
            stepFeedback[step].transform.position.Scale(scaleVector);
            stepFeedback[step].transform.position += Vector3.down * 20;
        }
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
        InputManager.instance.SignalNextBeat(step.input);

        feedbackCounters[firstPossibleKey]++;

        stepFeedback[step].GetComponent<FeedbackImage>().SwitchImageAndResetTimer((InputManager.Inputs)firstPossibleKey);
    }
    void CheckIfAllFeedbacksAreDone()
    {
        for (int i = 0; i < 4; i++)
        {
            if (feedbackCounters[i] > 2)
                if (i == 3)
                    stillNeedsFeedback = false;
            continue;
            break;
        }
    }
}
