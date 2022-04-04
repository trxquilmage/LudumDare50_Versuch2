using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MuiltipleChoiceTest : MonoBehaviour
{
    [SerializeField] GameObject popQuiz;
    [SerializeField] RectTransform timeBar;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] TextMeshProUGUI optionA;
    [SerializeField] TextMeshProUGUI optionB;
    [SerializeField] TextMeshProUGUI optionC;
    public List<Question> questions = new List<Question>();
    [HideInInspector] public float startShowingQuizTime = 0;
    public float startShowingQuizDelay;
    public float timeToAnswer;
    public float questionCooldown;
    float quizStartTime;
    float cooldownStartTime;
    float timeBarMaxScale;
    bool showQuizzes;
    bool quizActive;
    public bool QuizActive
    {
        get
        {
            return quizActive;
        }
        set
        {
            quizActive = value;
            if (value == true)
            {
                int i = Random.Range(0, questions.Count);
                question.text = questions[i].question;
                optionA.text = questions[i].optionA;
                optionB.text = questions[i].optionB;
                optionC.text = questions[i].optionC;
                currentQuestion = questions[i];
                quizStartTime = Time.time;
                popQuiz.SetActive(true);
            }
            else
            {
                popQuiz.SetActive(false);
            }
        }
    }


    [System.Serializable]
    public struct Question
    {
        public string question;
        public string optionA;
        public string optionB;
        public string optionC;
    }

    Question currentQuestion;

    // Start is called before the first frame update
    void Start()
    {
        timeBarMaxScale = timeBar.localScale.x;
        popQuiz.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startShowingQuizTime < Time.time && !showQuizzes)
        {
            showQuizzes = true;
            QuizActive = true;
            quizStartTime = Time.time;
        }

        if (showQuizzes)
        {
            if (QuizActive)
            {
                timeBar.localScale = new Vector3(ExtensionMethods.Remap(Time.time - quizStartTime, 0, timeToAnswer, timeBarMaxScale, 0), 0.013966f, 1f);
                if (quizStartTime + timeToAnswer < Time.time)
                {
                    // TO DO: stolpern!
                    QuizActive = false;
                    cooldownStartTime = Time.time;
                }
            }
            else
            {
                if (cooldownStartTime + questionCooldown < Time.time)
                {
                    QuizActive = true;
                }
            }

        }
    }

    public void CheckAnswer()
    {
        // TO DO: Feedback;
        QuizActive = false;
        cooldownStartTime = Time.time;
    }
}
