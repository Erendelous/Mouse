using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLayer : MonoBehaviour
{
    public Transform Player;
    public Transform PosChecker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.y > PosChecker.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = Player.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }
        else GetComponent<SpriteRenderer>().sortingOrder = Player.GetComponent<SpriteRenderer>().sortingOrder;
    }
}
