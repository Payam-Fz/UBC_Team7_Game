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

        /*foreach (var systemDiagram in systemDiagrams)
        {
            Debug.Log(systemDiagram.name);
        }*/
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
                //diagram.transform.Find("Button").GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
                //diagram.gameObject.GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.6f);
                Debug.Log("Not this one: " + diagram.gameObject.name);
            }
            else
            {
                diagram.color = new Color(1, 1, 1, 1);
                diagram.GetComponentInParent<Canvas>().sortingOrder = 6;
                //diagram.transform.Find("Button").GetComponent<Image>().color = new Color(1, 1, 1, 1);
                //diagram.gameObject.GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                Debug.Log("AYYYYYYYYYY: " + diagram.gameObject.name);
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
