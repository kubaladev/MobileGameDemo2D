using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float offsetYFromBottom = 0.5f;
    [SerializeField] InputManager inputManager;
    Rigidbody2D rigidBody2D;
    Camera cam;
    IInputStrategy selectedInputStrategy;
    float xInput;


    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        FixWorldPosition();   
    }
    private void Start()
    {
        selectedInputStrategy = inputManager.GetSelectedStrategy();
    }
    // Update is called once per frame
    void Update()
    {
        xInput = selectedInputStrategy.GetMovementInput();
    }

    // FixedUpdate is called in set interval when movement and collisions are calculated
    private void FixedUpdate()
    {
        Move();
    }

    // Move the player from side to side depending on the input
    private void Move()
    {
        rigidBody2D.velocity = new Vector2(xInput * speed, 0);
        Teleport();
    }

    // Fix the position of the player based on screen size width and height
    public void FixWorldPosition()
    {
        float fixedHeight = cam.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.safeArea.yMin)).y;
        transform.position = new Vector3 (transform.position.x, fixedHeight + +offsetYFromBottom);
        Teleport();
    }


    // Used to teleport the player object back to view on oposite site when leaving the screen
    private void Teleport()
    {
        Vector3 pos = cam.WorldToScreenPoint(transform.position);
        if (pos.x > (Screen.safeArea.xMax))
        {
            Vector3 newpos = new Vector3(Screen.safeArea.xMin, pos.y, pos.z);
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(newpos).x, transform.position.y, transform.position.z);
        }
        if (pos.x < Screen.safeArea.xMin)
        {
            Vector3 newpos = new Vector3(Screen.safeArea.xMax, pos.y, pos.z);
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(newpos).x, transform.position.y, transform.position.z);
        }
    }
}
