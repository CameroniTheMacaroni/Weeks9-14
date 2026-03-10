using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector2 movement;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;   
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
