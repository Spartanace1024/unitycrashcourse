using UnityEngine;

public class MissileAnimator : MonoBehaviour {
    public Animator missileAnimator;
    public ThrustController thrustController;
    
    // Start is called before the first frame update
    void Start() {
            
    }

    // Update is called once per frame
    void Update() {
        missileAnimator.SetBool("isRightThrust",thrustController.IsRightThrust);
        missileAnimator.SetBool("isLeftThrust",thrustController.IsLeftThrust);
        missileAnimator.SetBool("isBoosting",thrustController.IsBoosting);
        missileAnimator.SetTrigger("trigExplode");
    }
}
