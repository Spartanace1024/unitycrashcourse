using UnityEngine;

public class SaveEarthRunningState : SaveEarthState {
    private CollisionEnterBroadcaster missileCollisionEnterBroadcaster;
    private CollisionEnterBroadcaster meteorCollisionEnterBroadcaster;
    private TriggerExitBroadcaster boundsTriggerExitBroadcaster;
    private SaveEarthFSM saveEarthFsm;
    
    public override void OnStateEnter(SaveEarthFSM fsm) {
        saveEarthFsm = fsm;
        missileCollisionEnterBroadcaster = fsm.missile.GetComponent<CollisionEnterBroadcaster>();
        meteorCollisionEnterBroadcaster = fsm.goalMeteor.GetComponent<CollisionEnterBroadcaster>();
        boundsTriggerExitBroadcaster = fsm.boundsCamera.GetComponent<TriggerExitBroadcaster>();
        missileCollisionEnterBroadcaster.OnCollisionEnter += PlayerLost;
        meteorCollisionEnterBroadcaster.OnCollisionEnter += PlayerWin;
        boundsTriggerExitBroadcaster.OnTriggerExit += PlayerLost;
    }

    public override void OnStateUpdate(SaveEarthFSM fsm) {
        
    }

    public override void OnStateExit(SaveEarthFSM fsm) {
        missileCollisionEnterBroadcaster.OnCollisionEnter -= PlayerLost;
        meteorCollisionEnterBroadcaster.OnCollisionEnter -= PlayerWin;
        boundsTriggerExitBroadcaster.OnTriggerExit -= PlayerLost;
    }

    private void PlayerLost(Collision2D collision) {
        if (collision.gameObject.CompareTag("Objective")) {
            return;
        }
        PlayerLost();
    }

    private void PlayerLost(Collider2D collider) {
        PlayerLost();
    }

    private void PlayerLost() {
        saveEarthFsm.ChangeState(new SaveEarthEndState(false));
    }

    private void PlayerWin(Collision2D collision) {
        saveEarthFsm.ChangeState(new SaveEarthEndState(true));
    }
}
