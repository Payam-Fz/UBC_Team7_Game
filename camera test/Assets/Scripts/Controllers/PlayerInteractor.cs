﻿using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    //Collider2D overlap;
    bool canInteract = false;
    Collider2D interactiveCollider;
    [SerializeField] private TextMeshProUGUI interactText;
    
    void Start()
    {
        //overlap = Physics2D.OverlapCircle(transform.position, 5f, 8);
        //overlap.isTrigger = enabled;
    }

    private void Update()
    {
        if(canInteract && Input.GetKeyDown(KeyCode.E))
        {
            interactiveCollider.GetComponent<IInteractive>().Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractive>() != null)
        {
            interactiveCollider = collision;
            canInteract = true;
            interactiveCollider.GetComponent<Renderer>().material.SetFloat("_OutlineAlpha", 0.8f);
            //interactiveCollider.gameObject.GetComponent<SpriteRenderer>().material.shader = AllIn1Shader.Set
            //Color interactiveColor = interactiveCollider.gameObject.GetComponent<SpriteRenderer>().color;
            //interactiveCollider.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            //interactText.text = "Press [E] to interact";
            interactText.text = "Press [E] to interact";
            Debug.Log("Interactive Object Detected!");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractive>() != null)
        {
            interactiveCollider = collision;
            canInteract = false;
            interactiveCollider.GetComponent<Renderer>().material.SetFloat("_OutlineAlpha", 0);
            //interactiveCollider.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            interactText.text = "";
            Debug.Log("Leaving Interactive Object!");
        }
    }

    /*private IEnumerator PlayText(string text, string textHolder)
    {
        var charText = text.ToCharArray();
        foreach (char c in charText)
        {
            textHolder += c;
        }
            yield return new WaitForSeconds(0.01f);
        textHolder = text;
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractive>() != null)
        {
            Debug.Log("interactive!");
        }
    }*/


    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IInteractive>() != null)
        {
            Debug.Log("pp");
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.GetComponent<IInteractive>().Interact();
                Debug.Log("Interacted!");
            }
        }
    }*/
}
