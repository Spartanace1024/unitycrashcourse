using UnityEngine;
using UnityEngine.UI;

public class SaveEarthFSM : MonoBehaviour {
    public GameObject missile;
    public GameObject boundsCamera;
    public Button launchButton;
    public Button restartButton;
    public GameObject startMenu;
    public GameObject endMenu;
    
    private SaveEarthState currentState;

    private void Awake() {
        currentState = new SaveEarthStartState();
        currentState.OnStateEnter(this);
    }
    
    void Update() {   
        currentState.OnStateUpdate(this);
    }

    public void ChangeState(SaveEarthState newState) {
        if (newState != null) {
            currentState.OnStateExit(this);
            newState.OnStateEnter(this);
            currentState = newState;
        } else {
            currentState.OnStateExit(this);
        }
    }
}
