using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SystemPicker : MonoBehaviour
{
    [SerializeField] public GameObject[] bodySystems = new GameObject[6];
    List<Image> systemDiagrams = new List<Image>();
    
    
    void Start()
    {
        foreach(GameObject system in bodySystems)
        {
            systemDiagrams.Add(system.GetComponent<Image>());
        }
    }

    public void SelectSystem()
    {
        GameObject selectedSystem = FindSystem(EventSystem.current.currentSelectedGameObject.transform.parent.name);

        foreach(var diagram in systemDiagrams)
        {
            if(diagram.name != selectedSystem.name)
            {
                diagram.color = new Color(1, 1, 1, 0.2f);
                diagram.GetComponentInParent<Canvas>().sortingOrder = 5;
            }
            else
            {
                diagram.color = new Color(1, 1, 1, 1);
                diagram.GetComponentInParent<Canvas>().sortingOrder = 6;
            }
        }

        Debug.Log(selectedSystem.name);

        //foreach()
    }

    GameObject FindSystem(string systemName)
    {
        foreach(GameObject system in bodySystems)
        {
            if(system.name == systemName)
            {
                //Debug.Log(system.name);
                return system;
            }
            else
            {
                //Debug.LogError("System not found!");
            }
        }

        return null;
    }
}
