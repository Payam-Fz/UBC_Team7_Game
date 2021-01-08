using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DiseaseButton
{
    //[SerializeField] 
    public Button button;
    //[SerializeField] 
    public string name;
    //[SerializeField] 
    public int id = 0;
    //[SerializeField] 
    public Vector3 position;

    public DiseaseButton(Button diseaseButton, string diseaseName, int diseaseID, Vector3 buttonPosition)
    {
        diseaseName = this.name;
        diseaseID = this.id;
        buttonPosition = this.position;
    }
}
