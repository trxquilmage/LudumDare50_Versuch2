using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject ingameUI;
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] MuiltipleChoiceTest quiz;
    [SerializeField] FeedbackManager feedback;

    // Start is called before the first frame update
    void Start()
    {
        ingameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        ingameUI.SetActive(true);
        mainMenuUI.SetActive(false);
        quiz.startShowingQuizTime = Time.time + quiz.startShowingQuizDelay;
        BeatManager.instance.Gamestart();
        feedback.startFeedback = true;
        StartCoroutine(LerpCamera());
    }

    IEnumerator LerpCamera(){
        float elapsedTime = 0;
        float waitTime = 1f;
        Vector3 currentPos = Camera.main.transform.position;
        Vector3 gotoposition = new Vector3(27.2999992f,7.23999977f,11f);
        while (elapsedTime < waitTime)
        {
            Camera.main.transform.position = Vector3.Lerp(currentPos, gotoposition, (elapsedTime / waitTime));
            Camera.main.fieldOfView = Mathf.Lerp(18.8f, 35, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }  
        transform.position = gotoposition;
        yield return new WaitForSeconds(5f);
        elapsedTime = 0;
        waitTime = 200f;
        while (Camera.main.fieldOfView < 81)
        {
            Camera.main.fieldOfView = Mathf.Lerp(35, 120, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
