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


        private CharacterController controller;
        private Animator animator;
        private Vector2 movement;

        private bool isRunning = false;
        private float turnSmoothVelocity;

        private PlayerInteraction playerInteraction;


        void Start()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();

            playerInteraction = GetComponentInChildren<PlayerInteraction>();
        }

        private void FixedUpdate()
        {
            Vector3 direction = new Vector3(movement.x, 0f, movement.y).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +
                                    cameraTransform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                    turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                if (isRunning)
                {
                    controller.Move(moveDirection.normalized * runSpeed * Time.deltaTime);
                }
                else
                {
                    controller.Move(moveDirection.normalized * walkSpeed * Time.deltaTime);
                }
            }

            animator.SetFloat("Speed", direction.magnitude);
        }

        public void Move(InputAction.CallbackContext context)
        {
            movement = context.ReadValue<Vector2>();
        }

        public void Running(InputAction.CallbackContext context)
        {
            isRunning = context.performed;
            animator.SetBool("Running", isRunning);
        }

        public void Fire(InputAction.CallbackContext context)
        {
            playerInteraction.Interact();
        }
    }
}