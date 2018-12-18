using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStayBroadcaster : MonoBehaviour {
    public event Action<Collider2D> OnTriggerStay;
    public List<string> validCollisionTags;

    private void OnTriggerStay2D(Collider2D collider) {
        foreach (var tag in validCollisionTags) {
            if (collider.CompareTag(tag)) {
                OnTriggerStay?.Invoke(collider);
                return;
            }
        }
    }
}
