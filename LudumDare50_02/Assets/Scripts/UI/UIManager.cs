using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject ingameUI;
    [SerializeField] GameObject mainMenuUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        ingameUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }
}
