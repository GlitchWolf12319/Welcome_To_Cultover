using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


[CreateAssetMenu(menuName ="Input/Input Reader", fileName = "Input Reader")]

public class InputReader : ScriptableObject
{
    [SerializeField] private InputActionAsset _asset;


    public event UnityAction<Vector2> MoveEvent;
    public event UnityAction AttackEvent;
    public event UnityAction PossessEvent;



    private InputAction _moveAction;
    private InputAction _attackAction;
    private InputAction _possessAction;



    private void OnEnable()
    {
        _moveAction = _asset.FindAction("Move");

        _attackAction = _asset.FindAction("Attack");

        _possessAction = _asset.FindAction("Possess");



        _moveAction.started += onMove;
        _moveAction.performed += onMove;
        _moveAction.canceled += onMove;

       // _attackAction.started += onAttack;
      //  _attackAction.performed += onAttack;
      //  _attackAction.canceled += onAttack;


      
        _possessAction.started += onPossess;
        _possessAction.performed += onPossess;
        _possessAction.canceled += onPossess;



        _moveAction.Enable();
        _possessAction.Enable();
      //  _attackAction.Enable();

 
    }

    private void OnDisable()
    {
        
        _moveAction.started -= onMove;
        _moveAction.performed -= onMove;
        _moveAction.canceled -= onMove;

       // _attackAction.started -= onAttack;
       // _attackAction.performed -= onAttack;
       // _attackAction.canceled -= onAttack;

        _possessAction.started -= onPossess;
        _possessAction.performed -= onPossess;
        _possessAction.canceled -= onPossess;

         _moveAction.Disable();
        _possessAction.Disable();
        //_attackAction.Disable();
    }




    private void onMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());

    }

    private void onAttack(InputAction.CallbackContext context)
    {
        if(AttackEvent !=null && context.started)
        {
            AttackEvent.Invoke();
        }

    }
  private void onPossess(InputAction.CallbackContext context)
    {
        if(PossessEvent !=null && context.started)
        {
            PossessEvent.Invoke();
        }

    }


}
