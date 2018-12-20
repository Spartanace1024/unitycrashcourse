using UnityEngine.SceneManagement;
using UnityEngine;
public class SaveEarthEndState : SaveEarthState {
    private GameObject endMenu;
    private bool isWinner;
    public SaveEarthEndState(bool isWinner) {
        this.isWinner = isWinner;
    }
    
    public override void OnStateEnter(SaveEarthFSM fsm) {
        fsm.restartButton.onClick.AddListener(RestartGame);
        endMenu = fsm.endMenu;
        endMenu.SetActive(true);
    }

    public override void OnStateUpdate(SaveEarthFSM fsm) {
        
    }

    public override void OnStateExit(SaveEarthFSM fsm) {
        fsm.restartButton.onClick.RemoveListener(RestartGame);

    }

    private void RestartGame() {
        var scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
