using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractive
{
    SpriteRenderer doorSprite;
    [SerializeField] Sprite doorClosed;
    [SerializeField] Sprite doorClosedHL;
    [SerializeField] Sprite doorOpen;
    [SerializeField] Sprite doorOpenHL;

    [SerializeField] GameObject player;
    [SerializeField] Transform doorEntrance;
    [SerializeField] Transform doorExit;
    bool playerInRoom = false;

    
    void Start()
    {
        doorSprite = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (playerInRoom)
        {
            player.GetComponent<Rigidbody2D>().transform.position = doorEntrance.position;
            StartCoroutine(DoorDelay());
            playerInRoom = false;
        } 
        else
        {
            player.gameObject.GetComponent<Rigidbody2D>().transform.position = doorExit.position;
            StartCoroutine(DoorDelay());
            playerInRoom = true;
        }
    }

    public void ManualHighlight()
    {
        if(doorSprite.sprite == doorClosed)
        {
            doorSprite.sprite = doorClosedHL;
        }
        else if(doorSprite.sprite == doorClosedHL)
        {
            doorSprite.sprite = doorClosed;
        }
        else if(doorSprite.sprite == doorOpen)
        {
            doorSprite.sprite = doorOpenHL;
        }
        else if(doorSprite.sprite == doorOpenHL)
        {
            doorSprite.sprite = doorOpen;
        }
    }

    IEnumerator DoorDelay()
    {
        yield return new WaitForSeconds(1f);
    }

}
