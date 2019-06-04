using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject[] Interactibles;
    public Sprite Pressed;
    public Sprite Unpressed;
    public bool HoldButton = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<SpriteRenderer>().sprite = Pressed;
        foreach (var interactible in Interactibles)
        {
            interactible.GetComponent<InteractibleObject>().Activate();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (HoldButton)
        {
            GetComponent<SpriteRenderer>().sprite = Unpressed;
            foreach (var interactible in Interactibles)
            {
                interactible.GetComponent<InteractibleObject>().Deactivate();
            }
        }
    }
}
