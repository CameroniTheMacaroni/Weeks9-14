using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float dashMult = .3f;
    public Vector2 movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3) movement * speed*  Time.deltaTime;
    }

    public void onMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();

        if (context.phase == InputActionPhase.Started)
        {
            transform.position += new Vector3(dashMult*movement.x, dashMult * movement.y, 0);//add a little boost when the player first starts moving
        }
    }
}
