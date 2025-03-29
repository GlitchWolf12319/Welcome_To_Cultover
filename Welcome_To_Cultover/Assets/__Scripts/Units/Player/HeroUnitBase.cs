using UnityEngine;

public abstract class HeroUnitBase : UnitBase {
    private bool _canMove;

 

    private void OnMouseDown() {
      
    }

    public virtual void ExecuteMove() {
        // Override this to do some hero-specific logic, then call this base method to clean up the turn

        _canMove = false;
    }
}