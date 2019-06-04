using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pill : MonoBehaviour
{
    public bool Green;
    public bool Red;
    public bool Blue;
    public bool White;


    public Color PillCol;
    // Start is called before the first frame update
    void Start()
    {
        if (Green) PillCol = new Color(00, 64, 00, 255);
        else if (Blue) PillCol = new Color(00, 00, 64, 255);
        else if (Red) PillCol = new Color(64, 00, 00, 255);

        GetComponent<SpriteRenderer>().color = PillCol;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {

        PlayerManager player = other.GetComponent<PlayerManager>();
   

            if (Red)
            {
            player.LastPill.enabled = true;
            player.LastPill.color = player.Red;
                switch (player.LastColor)
                {
                    case PillColor.Green:
                        player.GetComponent<Renderer>().enabled = false;
                        break;
                    case PillColor.Blue:
                        Application.LoadLevel(Application.loadedLevel);
                        break;
                    default:
                        player.LastColor = PillColor.Red;
                        break;
                }
            }
            else if (Green)
            {
            player.LastPill.enabled = true;
            player.LastPill.color = player.Green;
            switch (player.LastColor)
                {
                    case PillColor.Blue:
                        player.ApplyPower(new Color(00,00,64,255),new Color(00,64,00,255));
                        
                        break;
                    case PillColor.Red:
                        player.ApplySpeed(new Color(64, 00, 00, 255), new Color(00, 64, 00, 255));
                        break;
                    default:
                        player.LastColor = PillColor.Green;
                        break;
                }


            }
            else if (Blue)
            {
            player.LastPill.enabled = true;
            player.LastPill.color = player.Blue;
            switch (player.LastColor)
                {
                    case PillColor.Green:
                        Application.LoadLevel(Application.loadedLevel);
                        break;
                    case PillColor.Red:
                        Application.LoadLevel(Application.loadedLevel);
                        break;
                    default:
                        player.LastColor = PillColor.Blue;
                        break;
                }

            }
            else if (White)
            {
                player.ClearAbilities();

            }
        Destroy(gameObject);


    }
}
