using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour, IInteractive
{
    DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
    }

    public void Interact()
    {
        dialogueManager.StartDialogue();
    }


    public void ManualHighlight()
    {
        throw new System.NotImplementedException();
    }
}
