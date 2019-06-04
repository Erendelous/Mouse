using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractibleClass
{
    Door,
    Dispenser
}
public class InteractibleObject : MonoBehaviour
{    
    public InteractibleClass ObjectClass;
    public float TimeToEnd;
    public float DeactivatorOffset;
    public PillColor Pill;
    public GameObject PillPrefab;
    private Pill _spawnedPillLink;
    private float _currentTime;
    private bool _isClosed = true;
    private bool _isTimerStarted = false;
    private PlayerManager player;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("mouse").GetComponent<PlayerManager>();
    }
    private void Update()
    {
        if (_isTimerStarted)
            _currentTime += Time.deltaTime;
        if (_currentTime > TimeToEnd)
        {

            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            _isTimerStarted = false;
        }
    }

    public void Activate()
    {
        switch (ObjectClass){
            case InteractibleClass.Dispenser:
                {
                    if(_spawnedPillLink==null&&player.LastColor!=Pill)ActivateDispenser();
                    break;
                }
            case InteractibleClass.Door:
                {
                    ActivateDoor();
                    break;
                }
        }
    }
    public void Deactivate()
    {
        switch (ObjectClass)
        {
            case InteractibleClass.Dispenser:
                {
                    DeactivateDispenser();
                    break;
                }
            case InteractibleClass.Door:
                {
                    DeactivateDoor();
                    break;
                }
        }
    }
    private void ActivateDoor()
    {

        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        _isClosed = false;
        _isTimerStarted = false;
        _currentTime = 0f;
    }
    
    private void DeactivateDoor()
    {
        if (_isClosed == false)
            _isTimerStarted = true;
    }

    private void ActivateDispenser()
    {
        
        Vector3 newPos = new Vector3(transform.position.x + DeactivatorOffset, transform.position.y, transform.position.z);
        Pill spawnedPill = Instantiate(PillPrefab, newPos, Quaternion.identity).GetComponent<Pill>();
        _spawnedPillLink = spawnedPill;
       // gameObject.GetComponent<BoxCollider2D>().enabled = false;
        switch (Pill)
        {
            case PillColor.Red:
                {
                    spawnedPill.Color = "Red";
                    break;
                }
            case PillColor.Blue:
                {
                    spawnedPill.Color = "Blue";
                    break;
                }
            case PillColor.Green:
                {
                    spawnedPill.Color = "Green";
                    break;
                }
            case PillColor.White:
                {
                    spawnedPill.Color = "White";
                    break;
                }

        }
    }
    private void DeactivateDispenser()
    {
       
    }
}
