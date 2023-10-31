using UnityEngine;
using UnityEngine.InputSystem;

namespace Entity.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;

        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;
        [SerializeField] private float turnSmoothTime;
        private Animator _animator;

        private CharacterController _controller;

        private bool _isRunning;
        private Vector2 _movement;

        private PlayerInteraction _playerInteraction;
        private float _turnSmoothVelocity;

        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Running = Animator.StringToHash("Running");

        
        public bool Controlled { get; set; }

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();

            _playerInteraction = GetComponentInChildren<PlayerInteraction>();
        }

        private void FixedUpdate()
        {
            if (!Controlled) return;
            
            var direction = new Vector3(_movement.x, 0f, _movement.y).normalized;

            if (direction.magnitude >= 0.1f)
            {
                var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +
                                  cameraTransform.eulerAngles.y;
                var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity,
                    turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                var moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                if (_isRunning)
                    _controller.Move(moveDirection.normalized * (runSpeed * Time.deltaTime));
                else
                    _controller.Move(moveDirection.normalized * (walkSpeed * Time.deltaTime));
            }

            _animator.SetFloat(Speed, direction.magnitude);
        }

        public void Move(InputAction.CallbackContext context)
        {
            _movement = context.ReadValue<Vector2>();
        }

        public void Run(InputAction.CallbackContext context)
        {
            _isRunning = context.performed;
            _animator.SetBool(Running, _isRunning);
        }

        public void Fire(InputAction.CallbackContext context)
        {
            _playerInteraction.Interact();
        }
    }
}