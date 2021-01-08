using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float playerSpeed = 10f;
    private Vector2 playerInput;

    private Rigidbody2D playerRb;
    private CapsuleCollider2D playerCollider;
    private Dictionary<string, Dictionary<string, Sprite[]>> sprites;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        sprites = new Dictionary<string, Dictionary<string, Sprite[]>>();
        FillDictionary();
    }

    private void FillDictionary()
    {
        int hairType = 1;
        int skinType = 1;
        int clothingType = 1;

        sprites.Add("Outline", new Dictionary<string, Sprite[]>());
        LoadDirectionSprites("Outline");
        sprites.Add("Skin", new Dictionary<string, Sprite[]>());
        LoadDirectionSprites("Skin");
        sprites.Add("Hair", new Dictionary<string, Sprite[]>());
        LoadDirectionSprites("Hair");
        sprites.Add("Clothing", new Dictionary<string, Sprite[]>());
        LoadDirectionSprites("Clothing");
        //sprites.Add("Outline", Resources.LoadAll<Sprite>("Character/Outline"));
        //GetComponent<SpriteRenderer>().sprite = 
        //Sprite[] hello = Resources.LoadAll<Sprite>("Character/Outline");
        //Debug.Log(sprites["Outline"].Length);
    }

    private void LoadDirectionSprites(string piece)
    {
        sprites[piece].Add("Front", Resources.LoadAll<Sprite>("Character/" + piece + "/Front"));
        sprites[piece].Add("RightFront", Resources.LoadAll<Sprite>("Character/" + piece + "/RightFront"));
        sprites[piece].Add("Right", Resources.LoadAll<Sprite>("Character/" + piece + "/Right"));
        sprites[piece].Add("RightBack", Resources.LoadAll<Sprite>("Character/" + piece + "/RightBack"));
        sprites[piece].Add("Back", Resources.LoadAll<Sprite>("Character/" + piece + "/Back"));
    }


    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3();
        
        playerInput.x = 1;
            //Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate()
    {
        playerRb.transform.Translate(playerInput * playerSpeed * Time.fixedDeltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Start Room")
        {
            playerRb.transform.position = new Vector3(-11.5f, 0.75f); //(-12.5f, 0.5f) <steph's scene
        }
        else if (collision.gameObject.name == "End Room")
        {
            playerRb.transform.position = new Vector3(-7.25f, 0.75f);
        }
    }

    /*
    private float playerSpeed = 10f;
    private Rigidbody2D playerRb;
    private CircleCollider2D playerCollider;
    private Vector2 playerInput;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        playerRb.transform.Translate(playerInput * Time.fixedDeltaTime * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Start Room")
        {
            playerRb.transform.position = new Vector3(-11f, 0.75f);
        } 
        else if (collision.gameObject.name == "End Room")
        {
            playerRb.transform.position = new Vector3(-7.25f, 0.75f);
        }
    }
    */
}
