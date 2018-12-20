using UnityEngine;

public class SaveEarthStartState : SaveEarthState {
    private GameObject startMenu;
    private ThrustController thrustController;
    private SaveEarthFSM saveEarthFsm;
    
    public override void OnStateEnter(SaveEarthFSM fsm) {
        saveEarthFsm = fsm;
        startMenu = fsm.startMenu;
        thrustController = fsm.missile.GetComponent<ThrustController>();
        fsm.launchButton.onClick.AddListener(OnLaunchButtonClicked);
    }

    public override void OnStateUpdate(SaveEarthFSM fsm) {
    }

    public override void OnStateExit(SaveEarthFSM fsm) {
        fsm.launchButton.onClick.RemoveListener(OnLaunchButtonClicked);
    }

    private void OnLaunchButtonClicked() {
        startMenu.SetActive(false);
        thrustController.enabled = true;
        saveEarthFsm.ChangeState(new SaveEarthRunningState());
    }
}
