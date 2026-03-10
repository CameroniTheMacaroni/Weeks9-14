using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 movement;
    public AudioSource SFX;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    public void OnAttact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SFX.Play();
        }
    }
    public void Onpoint(InputAction.CallbackContext context) {
        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
