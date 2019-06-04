using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLayer : MonoBehaviour
{
    public Transform Player;
    public Transform PosChecker;
    public float YDownOffset;
    private Vector3 _checkPos;
    // Start is called before the first frame update
    void Start()
    {
        _checkPos = new Vector3(transform.position.x, transform.position.y - YDownOffset, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (PosChecker != null)
        {
            if (Player.position.y > PosChecker.position.y)
            {
                GetComponent<SpriteRenderer>().sortingOrder = Player.GetComponent<SpriteRenderer>().sortingOrder + 1;
            }
            else GetComponent<SpriteRenderer>().sortingOrder = Player.GetComponent<SpriteRenderer>().sortingOrder;
        }
        else
        {
            if (Player.position.y > _checkPos.y)
            {
                GetComponent<SpriteRenderer>().sortingOrder = Player.GetComponent<SpriteRenderer>().sortingOrder + 1;
            }
            else GetComponent<SpriteRenderer>().sortingOrder = Player.GetComponent<SpriteRenderer>().sortingOrder;
        }
    }
}
