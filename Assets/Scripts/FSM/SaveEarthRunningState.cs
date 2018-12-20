using UnityEngine;

public class SaveEarthRunningState : SaveEarthState {
    private CollisionEnterBroadcaster missileCollisionEnterBroadcaster;
    private TriggerExitBroadcaster boundsTriggerExitBroadcaster;
    private SaveEarthFSM saveEarthFsm;
    
    public override void OnStateEnter(SaveEarthFSM fsm) {
        saveEarthFsm = fsm;
        missileCollisionEnterBroadcaster = fsm.missile.GetComponent<CollisionEnterBroadcaster>();
        boundsTriggerExitBroadcaster = fsm.boundsCamera.GetComponent<TriggerExitBroadcaster>();
        missileCollisionEnterBroadcaster.OnCollisionEnter += PlayerLost;
        boundsTriggerExitBroadcaster.OnTriggerExit += PlayerLost;
    }

    public override void OnStateUpdate(SaveEarthFSM fsm) {
        
    }

    public override void OnStateExit(SaveEarthFSM fsm) {
        missileCollisionEnterBroadcaster.OnCollisionEnter -= PlayerLost;
        boundsTriggerExitBroadcaster.OnTriggerExit -= PlayerLost;
    }

    private void PlayerLost(Collision2D collision) {
        PlayerLost();
    }

    private void PlayerLost(Collider2D collider) {
        PlayerLost();
    }

    private void PlayerLost() {
        saveEarthFsm.ChangeState(new SaveEarthEndState(false));
    }
}
