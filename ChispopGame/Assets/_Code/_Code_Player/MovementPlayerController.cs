//Diana Ramos 11/01//2022 Creation of the script

using UnityEngine;

namespace com.LazyGames.Chispop
{
    public class MovementPlayerController : MonoBehaviour
    {
        [Header("Options Movement")]
        [SerializeField] private float speed = 1;

        
        private CharacterController characterController;
        private Vector2 horizontalInput;
        private Vector3 mouseDirection;
    
        private void  Awake()
        {
            characterController = gameObject.GetComponent<CharacterController>();
        }
        private void FixedUpdate()
        {
           PlayerMovement();
           PlayerFacingTo();
        }
        public void ReceiveInput(Vector2 input, Vector2 mouseInput)
        {
            horizontalInput = input;
            mouseDirection = mouseInput;
        }
        void PlayerMovement()
        {
            Vector3 horizontalVelocity = (Vector3.right * horizontalInput.x + Vector3.forward * horizontalInput.y) * speed;
            characterController.Move(horizontalVelocity * Time.deltaTime);
        }
        void PlayerFacingTo()
        {
            Ray ray = Camera.main.ScreenPointToRay(mouseDirection);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;
    
            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                LookAt(point);
            }
        }
        void LookAt(Vector3 lookPoint)
        {
            Vector3 heightCorrectoPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
            transform.LookAt(heightCorrectoPoint);
        }
    }
}

