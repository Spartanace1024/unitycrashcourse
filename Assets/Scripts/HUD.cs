using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public float borderActivationDistance;
    public Image deathIndicatorBorder;
    public BoxCollider2D deathBoundsCollider;
    public TriggerStayBroadcaster gameBoundsTriggerStayBroadcaster;

    private Color deathIndicatorBorderColor;
    
    void Start() {
        gameBoundsTriggerStayBroadcaster.OnTriggerStay += UpdateDeathIndicatorBorder;
        deathIndicatorBorderColor = deathIndicatorBorder.color;
    }

    private void OnDisable() {
        gameBoundsTriggerStayBroadcaster.OnTriggerStay -= UpdateDeathIndicatorBorder;
    }

    private void UpdateDeathIndicatorBorder(Collider2D collider2D) {
        var distance = Mathf.Abs(collider2D.Distance(deathBoundsCollider).distance);
        var updatedColor = deathIndicatorBorderColor;
        updatedColor.a = Utility.Remap(distance, 0, borderActivationDistance, 1, 0);
        deathIndicatorBorder.color = updatedColor;
    }
}
