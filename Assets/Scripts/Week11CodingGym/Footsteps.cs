using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstep1;
    public AudioSource footstep2;
    public AudioSource footstep3;
    public AudioSource footstep4;
    public AudioSource footstep5;
    public AudioSource footstep6;
    public AudioSource footstep7;
    public AudioSource footstep8;
    public AudioSource footstep9;
    public AudioSource footstep0;

    public ParticleSystem particle;
    public int random;

    public CameraShake cameraShakeScript;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void onStep()
    {
        random = Random.Range(1, 10);
        particle.Emit(1000);
        cameraShakeScript.shakeCamera();
        switch (random)
        {
            case 1:
                footstep1.Play();
                break;
            case 2:
                footstep2.Play();
                break;
            case 3:
                footstep3.Play();
                break;
            case 4:
                footstep4.Play();
                break;
            case 5:
                footstep5.Play();
                break;
            case 6:
                footstep6.Play();
                break;
            case 7:
                footstep7.Play();
                break;
            case 8:
                footstep8.Play();
                break;
            case 9:
                footstep9.Play();
                break;
            case 10:
                footstep0.Play();
                break;
        }
    }
}
