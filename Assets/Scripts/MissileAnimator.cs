using UnityEngine;

public class MissileAnimator : MonoBehaviour {
    public Animator missileAnimator;
    public ThrustController thrustController;
    public ParticleSystem leftThrustParticleSystem;
    public ParticleSystem rightThrustParticleSystem;
    
    // Start is called before the first frame update
    void Start() {
            
    }

    // Update is called once per frame
    void Update() {
        //really no easy dependable way via editor to start and stop particle system
        leftThrustParticleSystem.Stop();
        rightThrustParticleSystem.Stop();
        if (thrustController.IsLeftThrust) {
            leftThrustParticleSystem.Play();
        }    
        if (thrustController.IsRightThrust) {
            rightThrustParticleSystem.Play();
        }    
        missileAnimator.SetBool("isBoosting",thrustController.IsBoosting);
    }
}
