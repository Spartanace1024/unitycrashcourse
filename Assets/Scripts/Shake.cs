using UnityEngine;

public class Shake : MonoBehaviour {
    public float shakeAmount;	
    
    private Vector3 originalPos;
	
    void Awake() {
        originalPos = transform.localPosition;
    }

    void Update() {
        if (shakeAmount > 0) {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
        } else {
            transform.localPosition = originalPos;
        }
    }
}