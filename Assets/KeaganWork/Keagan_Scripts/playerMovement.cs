using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    #region Input Mapping
    [SerializeField] private string actionMapName = "Player";
    [SerializeField] private InputActionAsset InputSystem;
    private string Move = "Move";
    public InputAction moveAction { get; private set; }
    #endregion Input Mapping

    private Vector2 moveInput;
    [SerializeField] float moveSpeed;

    [SerializeField] private GameObject headObject;

    // not my code 
    //Reference to code used: Faktory Studios.(2025, JUne 6), Make a PRO Third Person Camera (Unity + Cinemachine + Input System)
    [SerializeField] Transform camTransform;
    private bool faceMoveDirection = true;
    private CharacterController characterController;
    private float rotationTime = 3f;

    private Vector3 velocity;
    [SerializeField] private float gravity = -5f;

    public int headOffsetY;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        InputActionMap actionMapRef = InputSystem.FindActionMap(actionMapName);
        moveAction = actionMapRef.FindAction(Move);
        subscribeActiontoInput();
    }

  
    // Update is called once per frame
    void Update()
    {
        rotateHead();
        handleMovement();
        handleGravity();
    }
    void subscribeActiontoInput()
    {
        moveAction.performed += inputInfo => moveInput = inputInfo.ReadValue<Vector2>();
        moveAction.canceled += inputInfo => moveInput = Vector2.zero;
    }
    public void OnEnable()
    {
        InputSystem.FindActionMap(actionMapName).Enable();
    }
    public void OnDisable()
    {
        InputSystem.FindActionMap(actionMapName).Enable();
    }

    void handleMovement()
    {
        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;

        forward.y = 0 ;
        right.y  = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        
        if(faceMoveDirection && moveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation,toRotation, rotationTime * Time.deltaTime);
        }
    }

    void handleGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void rotateHead()
    {
        headObject.transform.rotation = camTransform.rotation;
    }


  
}
