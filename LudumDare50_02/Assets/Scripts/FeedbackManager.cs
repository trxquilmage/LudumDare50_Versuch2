using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackManager : MonoBehaviour
{
    [SerializeField] GameObject feebackImagePrefab;
    [SerializeField] GameObject canvas;
    Dictionary<Step, GameObject> stepFeedback = new Dictionary<Step, GameObject>();
    bool stillNeedsFeedback;
    bool ab;
    private void Update()
    {
        if (!ab)
            InstantiateFeedbackUnderneathEachStep();
        ab = true;
        UpdateFeedbackUnderneathEachStep();
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
        if (stillNeedsFeedback)
            return;

        Vector3 scaleVector = new Vector3(1, 1, 0);
        foreach (Step step in stepFeedback.Keys)
        {
            if (CheckIfStepIsInTheLowerHalf(step))
            {
                stepFeedback[step].GetComponent<Image>().color =
                    new Color(1, 1, 1, 0);
                continue;
            }
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
}
