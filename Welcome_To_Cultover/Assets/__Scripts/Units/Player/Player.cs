using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [Header("Input")]
    public InputReader _input;



    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;

    private Rigidbody2D rb;

    [SerializeField] private AudioClip _possessClip; 


    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        
    } 

    #region Input Events
    private void OnEnable()
    {
        _input.MoveEvent += OnMove;
        _input.PossessEvent += OnPossess;
    }

    private void OnDisable()
    {
        _input.MoveEvent -= OnMove;
        _input.PossessEvent -= OnPossess;
    }



    private void OnMove(Vector2 movement)
    {
        
        moveInput = movement;
    }
    

       private void OnPossess()
    {
        
        SoundManagerSO.PlayerSoundFXClip(_possessClip, transform.position, 1f);
    }

  

    #endregion
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Move();
        
    }


    private void Move()
    {
        rb.MovePosition(rb.position + moveInput * (moveSpeed * Time.deltaTime));
    }
}
