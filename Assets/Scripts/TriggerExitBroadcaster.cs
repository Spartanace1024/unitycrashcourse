using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitBroadcaster : MonoBehaviour {
    public event Action<Collider2D> OnTriggerExit;
    public List<string> validCollisionTags;

    private void OnTriggerExit2D(Collider2D collider) {
        foreach (var tag in validCollisionTags) {
            if (collider.CompareTag(tag)) {
                OnTriggerExit?.Invoke(collider);
                return;
            }
        }
    }
}
