using UnityEngine;
using UnityEngine.InputSystem;

public class LookController : MonoBehaviour
{
    public Vector3 playerRot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = playerRot;
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        playerRot = context.ReadValue<Vector3>();
    }
}
