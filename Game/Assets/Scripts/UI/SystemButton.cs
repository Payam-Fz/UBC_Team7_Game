using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SystemButton : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerExitHandler
{
    Image systemDiagram;
    Canvas systemCanvas;
    Image buttonImage;
    GameObject[] systemButtons;
    Button button;
    Button pressedButton;

    private void Start()
    {
        systemDiagram = GetComponentInParent<Image>();
        systemCanvas = GetComponentInParent<Canvas>();
        buttonImage = GetComponent<Image>();
        systemButtons = GetComponentInParent<SystemPicker>().bodySystems;
        button = GetComponent<Button>();
    }

    /*private void OnMouseOver()
    {
        systemDiagram.color = new Color(1, 1, 1, 0.2f);
        systemCanvas.sortingOrder = 6;
        buttonImage.color = new Color(1, 1, 1, 0.6f);
    }*/



    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach(var system in systemButtons)
        {
            if(system.name != transform.parent.name)
            {
                system.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
                //system.transform.Find("Button").GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
            }
            else
            {
                system.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            }
        }

        systemCanvas.sortingOrder = 6;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(eventData.clickTime > 1f)
        {

        }
        foreach (var system in systemButtons)
        {
            if (system.name != transform.parent.name && eventData.clickCount < 1)
            {
                system.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
                //system.transform.Find("Button").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
        systemCanvas.sortingOrder = 5;

        if(pressedButton!= null)
        {
            pressedButton.transform.parent.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        pressedButton = GetComponent<Button>();
        Debug.Log(pressedButton.transform.parent.name + "was pressed!");
    }

}
