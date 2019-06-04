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
public class PlayerManager : MonoBehaviour
{
    public float Movey;
    public float Movex;
    public float Speed;

    private float _startSpeed;

    public int Pills;
    public bool IsRight;

    public bool ForceAbility;
    public Image ForceIm;

    public bool SpeedAbility;

    public PillColor LastColor;

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
        if (collision.CompareTag("ForceWall") && ForceAbility)
        {
            Destroy(collision.gameObject);
        }
    }
    public void ApplyPower(Sprite one, Sprite two)
    {
        ForceAbility = true;
        LastPill.enabled = false;
        LastColor = PillColor.Empty;
    }
    public void ApplySpeed(Sprite first, Sprite second)
    {
        Speed *= 2;
        LastPill.enabled = false;
        LastColor = PillColor.Empty;
    }
    public void ClearAbilities()
    {
        Speed = _startSpeed;
        LastPill.enabled = false;
        LastColor = PillColor.Empty;
        ForceAbility = false;
        GetComponent<Renderer>().enabled = true;
    }

}
