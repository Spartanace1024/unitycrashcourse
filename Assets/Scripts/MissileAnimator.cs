using UnityEngine;

public class MissileAnimator : MonoBehaviour {
    public Animator missileAnimator;
    public ThrustController thrustController;
    public CollisionEnterBroadcaster collisionEnterBroadcaster;
    public GameObject explode;
    
    // Start is called before the first frame update
    void Start() {
        collisionEnterBroadcaster.OnCollisionEnter += Explode;
    }

    private void OnDisable() {
        collisionEnterBroadcaster.OnCollisionEnter -= Explode;
    }

    // Update is called once per frame
    void Update() {
        missileAnimator.SetBool("isRightThrust",thrustController.IsRightThrust);
        missileAnimator.SetBool("isLeftThrust",thrustController.IsLeftThrust);
        missileAnimator.SetBool("isBoosting",thrustController.IsBoosting);
    }

    private void Explode(Collision2D enemy) {
        Instantiate(explode, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
