using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private AudioClip bounceSound;
    
    public float dragLimit = 3f;
    public float forceToAdd = 10f;

    public static bool canInput = true;
    
    private Camera cam;
    private bool isDragging = false;
    private LineRenderer line;
    private Rigidbody2D rb;

    Vector3 MousePosition
    {
        get
        {
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            return pos;
        }
    }
    private bool IsThrown => Mathf.Approximately(rb.gravityScale, defaultGravity);
    private Vector3 startPosition = new Vector3();
    private float defaultGravity;

    private void Awake()
    {
        cam = Camera.main;
        line = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        canInput = true;
        defaultGravity = rb.gravityScale;
        startPosition = transform.position;
        ResetBall();
    }

    private void Update()
    {
        if (!canInput)
        {
            ResetDrag();
            return;
        }
        
        if (!IsThrown)
        {
            if (Input.GetMouseButtonDown(0) && !isDragging)
            {
                DragStart();
            }

            if (isDragging)
            {
                Drag();
            }

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                DragEnd();
            }
        }
    }
    
    private void DragStart()
    {
        line.enabled = true;
        isDragging = true;
        line.SetPosition(0, startPosition);
    }

    private void Drag()
    {
        Vector3 startPos = line.GetPosition(0);
        Vector3 currentPos = MousePosition;

        Vector3 distance = currentPos - startPos;

        if (distance.magnitude <= dragLimit)
        {
            line.SetPosition(1, currentPos);
        }
        else
        {
            Vector3 limitVector = startPos + (distance.normalized * dragLimit);
            line.SetPosition(1, limitVector);
        }
    }

    private void DragEnd()
    {
        rb.gravityScale = defaultGravity;
        
        isDragging = false;
        line.enabled = false;
        
        Vector3 startPos = line.GetPosition(0);
        Vector3 currentPos = line.GetPosition(1);

        Vector3 distance = currentPos - startPos;
        Vector3 finalForce = distance * forceToAdd;
        rb.AddForce(-finalForce, ForceMode2D.Impulse);
    }

    private void ResetDrag()
    {
        rb.gravityScale = 0;

        isDragging = false;
        line.enabled = false;

        transform.position = startPosition;
        
        rb.velocity = Vector2.zero;
    }
    
    public void ResetBall()
    {
        isDragging = false;
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        rb.gravityScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Bounce"))
        {
            SoundManager.Instance.PlayBounceSound(bounceSound);
        }
    }
}
