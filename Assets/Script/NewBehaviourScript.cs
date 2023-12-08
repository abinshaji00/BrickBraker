using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public GameObject brickeffect;
    public ParticleSystem brickeffectParticleSystem;
    public Collider2D col1;
    public void Update()
    {
        if (col1.gameObject.name == "ball")
        {
            brickeffectParticleSystem.Play();
        }
            
    }
}
