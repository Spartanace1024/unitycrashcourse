using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveEarthEndState : SaveEarthState {
    private GameObject loseMenu;
    private GameObject winMenu;
    private bool isWinner;
    
    public SaveEarthEndState(bool isWinner) {
        this.isWinner = isWinner;
    }
    
    public override void OnStateEnter(SaveEarthFSM fsm) {
        fsm.restartButton.onClick.AddListener(RestartGame);
        fsm.quitButton.onClick.AddListener(RestartGame);
        winMenu = fsm.winMenu;
        loseMenu = fsm.loseMenu;
        
        if (isWinner) {
            winMenu.SetActive(true);
        } else {
            loseMenu.SetActive(true);   
        }
    }

    public override void OnStateUpdate(SaveEarthFSM fsm) {
        
    }

    public override void OnStateExit(SaveEarthFSM fsm) {
        fsm.restartButton.onClick.RemoveListener(RestartGame);
        fsm.quitButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame() {
        var scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
