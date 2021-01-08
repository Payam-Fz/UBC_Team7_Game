using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiagnosisTree : MonoBehaviour
{
    [SerializeField] DiseaseButton[] diseaseButtons;
    //[SerializeField] Button[] symptomButtons;

    void Start()
    {
        int idCounter = 0;
        foreach(var button in diseaseButtons)
        {
            button.name = button.button.GetComponentInChildren<Text>().text;
            button.id = idCounter;
            idCounter++;
            button.position = button.button.GetComponent<RectTransform>().position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Diagnose()
    {

    }
}
