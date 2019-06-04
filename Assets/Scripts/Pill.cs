using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pill : MonoBehaviour
{
    public string Color;

    public Sprite[] PillSprites;
    // Start is called before the first frame update
    void Start()
    {
        switch (Color)
        {
            case "Red":
                GetComponent<SpriteRenderer>().sprite = PillSprites[0];
                break;
            case "Green":
                GetComponent<SpriteRenderer>().sprite = PillSprites[1];
                break;
            case "Blue":
                GetComponent<SpriteRenderer>().sprite = PillSprites[2];
                break;
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {

        PlayerManager player = other.GetComponent<PlayerManager>();

        switch (Color) {
            case "Red":
            {
            player.LastPill.enabled = true;
            player.LastPill.sprite = PillSprites[0];
                switch (player.LastColor)
                {
                    case PillColor.Green:
                        player.GetComponent<Renderer>().enabled = false;
                        break;
                    case PillColor.Blue:
                        Application.LoadLevel(Application.loadedLevel);
                        break;
                    default:
                            player.LastPill.sprite = PillSprites[0];
                            player.LastColor = PillColor.Red;
                        break;
                }
            }break;
            case "Green":
            {
            player.LastPill.enabled = true;
                    player.LastPill.sprite = PillSprites[1];
            switch (player.LastColor)
                {
                    case PillColor.Blue:
                        player.ApplyPower(PillSprites[2],PillSprites[1]);
                        
                        break;
                    case PillColor.Red:
                        player.ApplySpeed(PillSprites[0], PillSprites[2]);
                        break;
                    default:
                            player.LastPill.sprite = PillSprites[1];
                            player.LastColor = PillColor.Green;
                        break;
                }


            }break;
            case "Blue":
            {
            player.LastPill.enabled = true;
                    player.LastPill.sprite = PillSprites[2];
            switch (player.LastColor)
                {
                    case PillColor.Green:
                        Application.LoadLevel(Application.loadedLevel);
                        break;
                    case PillColor.Red:
                        Application.LoadLevel(Application.loadedLevel);
                        break;
                    default:
                            player.LastPill.sprite = PillSprites[2];
                            player.LastColor = PillColor.Blue;
                        break;
                }

            }break;
            default:
                player.ClearAbilities();
                break;
            }
        Destroy(gameObject);


    }
}
