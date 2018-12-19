using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameFSM : MonoBehaviour {
    public ThrustController missileThrustController;
    public GameObject menu;
    public Button launchButton;
    
    private GameState currentState;
    // Start is called before the first frame update
    void Start() {
        currentState = GameState.GameStart;
        launchButton.onClick.AddListener(() => {
            if (currentState == GameState.GameStart) {
                currentState = GameState.GameRunning;
                menu.SetActive(false);
                missileThrustController.enabled = true;
            }
        });

    }

    // Update is called once per frame
    void Update() {
        switch (currentState) {
            case GameState.GameStart:
                break;
            case GameState.GameRunning:
                
                break;
            case GameState.GameEnd:
                
                break;
        }
        
    }

    private enum GameState {
        GameStart,
        GameRunning,
        GameEnd
    }
}
