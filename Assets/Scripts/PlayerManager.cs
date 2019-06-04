using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum PillColor
{
    Red,
    Green,
    Blue,
    White,
    Empty
}
public enum Abilities
{
    Force,
    Speed,
    Invisibility,
    Empty
}

public class PlayerManager : MonoBehaviour
{
    public float Movey;
    public float Movex;
    public float Speed;

    private float _startSpeed;

    public int Pills;
    public bool IsRight;

    public Abilities CurrentAbility;
    public PillColor LastColor;

    public Sprite ForceAb;
    public Sprite SpeedAb;
    public Sprite InvisAb;
   /* public int RPills;
    public int GPills;
    public int BPills;

    */
    private Rigidbody2D _rb;


    public Image LastPill;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startSpeed = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Movex = Input.GetAxis("Horizontal") * Speed*1000 * Time.deltaTime;
        Movey = Input.GetAxis("Vertical") * Speed*1000 * Time.deltaTime;

        _rb.AddForce(Vector2.up * Movey);
        _rb.AddForce(Vector2.right * Movex);

        if (Movex < 0)
        {
            transform.localScale = new Vector3(-1.3775f, 1.3775f, 1.3775f);
            IsRight = false;
        }
        else if (Movex > 0)
        {
            transform.localScale = new Vector3(1.3775f, 1.3775f, 1.3775f);
            IsRight = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ForceWall") && CurrentAbility==Abilities.Force)
        {
            Destroy(collision.gameObject);
        }
    }
    public void ApplyPower(Sprite one, Sprite two)
    {
        CurrentAbility = Abilities.Force;
        LastPill.sprite = ForceAb;
        LastColor = PillColor.Empty;
    }
    public void ApplySpeed(Sprite first, Sprite second)
    {
        CurrentAbility = Abilities.Speed;
        Speed *= 2;
        LastPill.sprite = SpeedAb;
        LastColor = PillColor.Empty;
    }
    public void ClearAbilities()
    {
        CurrentAbility = Abilities.Empty;
        Speed = _startSpeed;
        LastPill.enabled = false;
        LastColor = PillColor.Empty;
        
        GetComponent<Renderer>().enabled = true;
    }

}
