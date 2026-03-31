using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void shakeCamera()
    {
        impulseSource.GenerateImpulse();
    }
}
