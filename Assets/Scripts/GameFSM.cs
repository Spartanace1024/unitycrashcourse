using UnityEngine;
using UnityEngine.UI;

public class GameFSM : MonoBehaviour {
    public BoxCollider2D cameraCollider;
    public TriggerExitBroadcaster gameBoundsTriggerExitBroadcaster;
    public TriggerStayBroadcaster gameBoundsTriggerStayBroadcaster;
    public Image redUI;
    // Start is called before the first frame update
    void Start() {
        gameBoundsTriggerExitBroadcaster.OnTriggerExit += CheckGameOver;
        gameBoundsTriggerStayBroadcaster.OnTriggerStay += CheckBoundsAlmost;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void CheckGameOver(Collider2D collider2D) {
        Debug.Log("Game Over!");
    }

    private void CheckBoundsAlmost(Collider2D collider2D) {
        var distance = Mathf.Abs(collider2D.Distance(cameraCollider).distance);
        redUI.color = new Color(255,0,0,Remap(distance, 0, 3f, 1, 0));
    }
    
    public float Remap (float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
   
}
