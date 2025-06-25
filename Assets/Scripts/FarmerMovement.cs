using UnityEngine;

public class FarmerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private Animator _animator;
    private Vector2 _lastMoveDir =  Vector2.down;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        SnapToGrid();
    }

    
    void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        
        bool isMoving = _moveInput.sqrMagnitude > 0.01f;
        
        // save last move direction when moving 
        if (isMoving)
        {
            _lastMoveDir = _moveInput.normalized;
        }

        // anime movement 
        _animator.SetFloat(AnimationStrings.moveX,_lastMoveDir.x);
        _animator.SetFloat(AnimationStrings.moveY, _lastMoveDir.y);
        _animator.SetBool(AnimationStrings.isMoving, isMoving);
        
        _moveInput.Normalize(); 
        
        Debug.Log("Dir X: " + _lastMoveDir.x + " | Dir Y: " + _lastMoveDir.y);
       
    }

    void SnapToGrid()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Round(pos.x);
        pos.y = Mathf.Round(pos.y);
        transform.position = pos;
    }
    
    void FixedUpdate()
    {
        // move the character using physics 
        _rb.MovePosition(_rb.position + _moveInput * (moveSpeed * Time.fixedDeltaTime));
    }
    
  
}
