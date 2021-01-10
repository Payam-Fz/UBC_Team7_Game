using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour, IInteractive
{
    DialogueManager dialogueManager;

    public void Interact()
    {
        dialogueManager.StartDialogue();
    }


    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ManualHighlight()
    {
        throw new System.NotImplementedException();
    }
}
