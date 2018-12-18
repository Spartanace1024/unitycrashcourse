using UnityEngine;

public class ThrustController : MonoBehaviour {
    public float forwardForce;
    public float addedBoostForce;
    public float turnForce;
    public Transform forcePosition;
    public Transform leftForcePosition;
    public Transform rightForcePosition;
    
    private Rigidbody2D _rigidbody2D;
    private float horizontalInput;
    private bool isBoosting;
    private bool isLeftThrust;
    private bool isRightThrust;

    // Start is called before the first frame update
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        isBoosting = Input.GetButton("Jump");
    }

    private void FixedUpdate() {
        var direction = transform.position - forcePosition.position;
        var currentForce = forwardForce;
        
        if (isBoosting) {
            currentForce += addedBoostForce;
        }
        _rigidbody2D.AddForceAtPosition(direction.normalized*currentForce,forcePosition.position);
        
        if (horizontalInput > 0) {
            _rigidbody2D.AddForceAtPosition(leftForcePosition.up*turnForce,leftForcePosition.position);
        }
        
        if (horizontalInput < 0) {
            _rigidbody2D.AddForceAtPosition(rightForcePosition.up*turnForce,rightForcePosition.position);
        }
    }

    public bool IsBoosting {
        get {
            return isBoosting;
        }
    }

    public bool IsLeftThrust {
        get {
            return horizontalInput > 0;
        }
    }
    
    public bool IsRightThrust {
        get {
            return horizontalInput < 0;
        }
    }

}
