using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour, IInteractive
{
    SpriteRenderer tvSprite;
    [SerializeField] Sprite tvOn;
    [SerializeField] Sprite tvOff;

    void Start()
    {
        tvSprite = GetComponent<SpriteRenderer>();
    }
    
    public void Interact()
    {
        if(tvSprite.sprite == tvOff)
        {
            tvSprite.sprite = tvOn;
        } 
        else if(tvSprite.sprite == tvOn)
        {
            tvSprite.sprite = tvOff;
        }
    }


}
