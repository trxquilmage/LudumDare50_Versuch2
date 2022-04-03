using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuiltipleChoiceTest : MonoBehaviour
{
    [SerializeField] GameObject timeBar;
    public float startShowingQuizTime;
    public float timeToAnswer;
    float quizStartTime;
    bool showQuizzes;
    bool quizActive;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startShowingQuizTime < Time.time && !showQuizzes)
        {
            showQuizzes = true;
        }

        if (showQuizzes)
        {
            if (quizActive)
            {
                if (quizStartTime + timeToAnswer < Time.time)
                {
                    // TO DO: stolpern!
                }
            }


        }

    }
}
