using Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Entity.Player
{
    public class PlayerController : SingletonMonoBehaviour<PlayerController>
    {
        
        protected override bool IsDontDestroyOnLoad()
        {
            return false;
        }
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Running = Animator.StringToHash("Running");
        [SerializeField] private Transform cameraTransform;

        [Range(1, 5)] [SerializeField] private float walkSpeed;

        [Range(2, 10)] [SerializeField] private float runSpeed;

        [Range(0f, 0.1f)] [SerializeField] private float turnSmoothTime;

        private Vector2 _movement;
        private Animator _animator;

        private CharacterController _controller;

        private bool _isRunning;

        private PlayerInteraction _playerInteraction;
        private float _turnSmoothVelocity;

        private Vector3 _direction;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();

            _playerInteraction = GetComponentInChildren<PlayerInteraction>();
        }

        private void Update()
        {
            _direction = new Vector3(_movement.x, 0f, _movement.y).normalized;

            if (_direction.magnitude >= 0.1f)
            {
                var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg +
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
        }

        private void LateUpdate()
        {
            _animator.SetFloat(Speed, _direction.magnitude);
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