using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Components

    [SerializeField] private CharacterController _characterController; // 캐릭터 컨트롤러
    [SerializeField] private Animator _animator; // 애니메이터

    #endregion Components

    #region Fields

    // 캐릭터의 이동 관련 변수
    [SerializeField] private Transform cameraTransform; // 캐릭터를 비추는 카메라
    [SerializeField] private float moveSpeed = 1.0f; // 이동 속도
    [SerializeField] private float rotateSpeed = 1.0f; // 회전 속도
    private Vector2 inputVector = Vector2.zero; // 입력 벡터
    private Vector3 moveVector = Vector3.zero; // 실제 이동 벡터

    #endregion Fields

    #region Unity Life Cycle Methods

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
    }

    #endregion Unity Life Cycle Methods

    #region Input Systems

    // 입력을 받아 캐릭터의 이동 방향을 결정하는 함수
    private void OnMove(InputAction.CallbackContext callbackContext)
    {
        inputVector = callbackContext.ReadValue<Vector2>();
    }

    #endregion Input Systems

    #region Custom Methods

    // 캐릭터를 이동시킨다.
    private void Move()
    {
        // 캐릭터의 이동을 구현한다.
        moveVector = inputVector.x * cameraTransform.right + inputVector.y * cameraTransform.forward; // 캐릭터의 이동 방향은 카메라가 바라보는 방향을 기준으로 한다.
        moveVector.y = 0f; // 캐릭터는 위아래로 이동하지 않는다.
        moveVector.Normalize(); // 이동 벡터를 정규화한다.
        _characterController.SimpleMove(moveVector * moveSpeed); // 캐릭터 컨트롤러의 이동 함수를 사용하여 캐릭터를 이동시킨다.

        // 캐릭터의 회전을 구현한다.
        if (moveVector != Vector3.zero) // 캐릭터가 이동할 때만 몸을 돌린다.
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveVector), rotateSpeed * Time.deltaTime); // 캐릭터를 이동 방향으로 서서히 회전시킨다.
        }
    }

    #endregion Custom Methods

}
