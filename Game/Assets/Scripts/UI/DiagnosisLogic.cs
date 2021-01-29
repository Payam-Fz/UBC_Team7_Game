using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DiagnosisLogic : MonoBehaviour {

    #region Variables
    [SerializeField]
    GameObject buttonPrefab;
    [SerializeField] 
    RectTransform canvasTransform;
    [SerializeField]
    List<GameObject> buttons;
    List<float> yPositions;
    DiagnosisTreeNode currentRoot;
    string buttonPressed;
    List<List<GameObject>> buttonRoots = new List<List<GameObject>>();
    #endregion

    private void Start()
    {
        currentRoot = MainTree.tree;
        buttons = new List<GameObject>();
        //canvasTransform = GetComponentInParent<RectTransform>();
        yPositions = GetButtonPositions();

        //currentChildren = tree.GetChildren();

        //Debug.Log(canvasTransform.rect.height);
        
        //Debug.LogFormat("Number of Buttons: {0}", buttons.Count());        
    }

    public void RecordButton()
    {
        buttonPressed = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(buttonPressed);

        if(buttonPressed == "Start")
        {
            buttonPressed = null;
        }

        if (currentRoot.isFinal)
            Debug.Log(currentRoot.GetDiagnosis());
    }

    public void CreateButtons()
    {
        //List<GameObject> lastButtons = buttons;

        if(buttonPressed != null) 
        currentRoot = currentRoot.GetChild(buttonPressed);

        yPositions = GetButtonPositions();
        
        foreach (var button in buttons)
        {
            button.SetActive(false);
        }
        StoreButtons(buttons);
        buttons.Clear();

        foreach (var child in currentRoot.GetChildren())
        {
            var emptyButton = Instantiate(buttonPrefab, gameObject.transform);
            //buttonPrefab.GetComponent<RectTransform>().parent = gameObject.transform;
            //emptyButton.GetComponent<Button>().onClick.AddListener(() => CreateButtons());
            emptyButton.GetComponentInChildren<TextMeshProUGUI>().text = child;
            emptyButton.SetActive(true);
            //Debug.Log(child);
            buttons.Add(emptyButton);
        }

        for (int i = 0; i < currentRoot.GetChildren().Count; i++)
        {
            Vector3 p = buttons[i].GetComponent<RectTransform>().position;
            Debug.Log(p);
            p.y += yPositions[i];
            //Debug.Log(p.y);
            buttons[i].GetComponent<RectTransform>().position = p;
        }
    }

    List<float> GetButtonPositions()
    {
        int children = currentRoot.GetChildren().Count();
        List<float> childrenYPos = new List<float>();
        float buttonSpacing = canvasTransform.rect.height / (children + 1);
        Debug.Log(buttonSpacing);

        if (children%2 == 1)
        {
            for(int i = children / 2; i >= -1 * children / 2; i--)
            {
                childrenYPos.Add(i * buttonSpacing);
            }
        }
        else
        {
            for (int i = children / 2 - 1; i >= -1 * children / 2; i--)
            {
                childrenYPos.Add(i * buttonSpacing + buttonSpacing / 2);
            }
        }

        return childrenYPos;
    }


    void StoreButtons(List<GameObject> currentButtons)
    {
        if(!buttonRoots.Contains(currentButtons))
        {
            buttonRoots.Add(currentButtons);
        }
    }

}
    
/*public static void TreeMethod()
    {
        DiagnosisTreeNode currentNode = MainTree.tree;

        while (!currentNode.isFinal) 
        {
          StringBuilder sb = new StringBuilder("", 100);
          List<string> children = currentNode.GetChildren();
          for (int i = 0; i < children.Count; i++) 
          {
            sb.AppendFormat("{0}. {1}  ", i, children[i]);
          }

          Console.WriteLine("Please choose from among the options:");
          Console.WriteLine("{0}", sb.ToString());

          Console.WriteLine("");

          string userInput = Console.ReadLine();
          if (children.Contains(userInput)) 
          {
            Console.WriteLine("");
            Console.WriteLine("You have chosen input {0}", userInput);
            currentNode = currentNode.GetChild(userInput);
          }
          else 
          {
            Console.WriteLine("Unexpected input, please make sure the input is the same as the presented strings");
          }
        }
    
        Console.WriteLine("");
        Console.WriteLine("Your Diagnosis is: {0}", currentNode.GetDiagnosis());
    
  
    }*/

/*new DiagnosisTreeNode("C")
    {
      new DiagnosisTreeNode("J", true)
      {
        new DiagnosisTreeNode("Diagnosis 5"),
      },
      new DiagnosisTreeNode("K", true)
      {
        new DiagnosisTreeNode("Diagnosis 6"),
      },
      new DiagnosisTreeNode("L")
      {
        new DiagnosisTreeNode("M", true)
          {
            new DiagnosisTreeNode("Diagnosis 7"),
          },
          new DiagnosisTreeNode("N", true)
          {
            new DiagnosisTreeNode("Diagnosis 8"),
          },
      },
    }*/


/*public static void Main(string[] args)
{
    Console.WriteLine("Enter 1 for the several choices method and 2 for the flowchart/tree method: ");

    string userInput = Console.ReadLine();

    if (userInput == "1")
    {
        DiagnosisLogic.OldMethod();
    }
    else if (userInput == "2")
    {
        DiagnosisLogic.TreeMethod();
    }
}

public static void OldMethod()
{
    Console.WriteLine("Hello World");

    // A dictionary containing disease names with an array of indices of symptom strings
    Dictionary<string, int[]> diseaseDict = new Dictionary<string, int[]>();

    diseaseDict.Add("Food Poisoning", new int[] { 0, 3, 4 });
    diseaseDict.Add("Migraine", new int[] { 1, 3 });
    diseaseDict.Add("Arthritis", new int[] { 2, 5 });

    string[] symptoms = { "Vomitting", "Headache", "Joint Ache", "Nausea", "Diarrhea", "Swelling" };

    Console.WriteLine("Choose the indexes of the following diseases (enter a comma separated list of integers):");


    StringBuilder sb = new StringBuilder("", 100);
    for (int i = 0; i < symptoms.Length; i++)
    {
        sb.AppendFormat("{0}. {1}  ", i, symptoms[i]);
    }

    Console.WriteLine("{0}", sb.ToString());
    Console.WriteLine("");

    string userInput = Console.ReadLine();
    string[] symptomsStrings = userInput.Split(',');
    int[] observedSymptoms = new int[symptomsStrings.Length];
    for (int j = 0; j < symptomsStrings.Length; j++)
    {
        symptomsStrings[j] = symptomsStrings[j].Trim();
    }

    try
    {
        for (int j = 0; j < symptomsStrings.Length; j++)
        {
            observedSymptoms[j] = Int32.Parse(symptomsStrings[j]);
        }
    }
    catch (FormatException e)
    {
        Console.WriteLine(e.Message);
    }

    Array.Sort(observedSymptoms);

    string disease = "No Matching Disease Found!";

    foreach (KeyValuePair<string, int[]> entry in diseaseDict)
    {
        int[] diseaseSymptoms = entry.Value;
        if (diseaseSymptoms.ToList().SequenceEqual(observedSymptoms.ToList()))
        {
            disease = entry.Key;
        }
    }

    Console.WriteLine(disease);
}*/
