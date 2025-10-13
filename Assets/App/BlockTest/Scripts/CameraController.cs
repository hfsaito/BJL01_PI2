using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity;
    
    private Rigidbody2D _rigidbody;
    
    private Vector2 _lastMousePosition;

    [SerializeField]
    private bool isDragging;
    
    private ScreenCaptureManager _screenCaptureManager;
   
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _screenCaptureManager = new ScreenCaptureManager();
        _screenCaptureManager.CreateDirectory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            _lastMousePosition = Input.mousePosition;
            isDragging = true;
        }
        
        if (Input.GetMouseButtonUp(2))
        {
            isDragging = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(_screenCaptureManager.CaptureScreenShot());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            
        }
    }

    private void FixedUpdate()
    {
        if (isDragging && Input.GetMouseButton(2))
        {
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 mouseDelta = currentMousePosition - _lastMousePosition;
            
            Vector2 moveDirection = new Vector2(-mouseDelta.x, -mouseDelta.y);
            moveDirection *= mouseSensitivity * 0.01f;
        
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 newPosition = currentPosition + moveDirection;
            
            _rigidbody.MovePosition(newPosition);
            _lastMousePosition = currentMousePosition;
        }
    }
}
