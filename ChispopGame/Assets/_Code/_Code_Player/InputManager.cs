//Diana Ramos 11/01//2022 Creation of the script

using UnityEngine;

namespace com.LazyGames.Chispop
{
    public class InputManager : MonoBehaviour
    {
        private ShootPlayer shootPlayer;
        private MovementPlayerController movementPlayerController;
        private InputController inputController;
        private InputController.PlayerActions playerActions;
        private Vector2 horizontalInput;
        private Vector2 mouseDirection;

        private void Awake()
        {
            movementPlayerController = gameObject.GetComponent<MovementPlayerController>();
            shootPlayer = gameObject.GetComponent<ShootPlayer>();
            inputController = new InputController();
            playerActions = inputController.Player;

            //Syntax to pass events of Input 
            //ShootWeapon is the method inside ShootPlayer Script
            playerActions.Shoot.performed += _ => shootPlayer.ShootWeapon();
            playerActions.Movement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
            playerActions.MousePosition.performed += ctx => mouseDirection = ctx.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            // Fixed the  player movement 
            movementPlayerController.ReceiveInput(horizontalInput,mouseDirection);
        }
        
        //DO NOT TOUCH
        private void OnEnable()
        {
            inputController.Enable();
        }
        private void OnDisable()
        {
            inputController.Disable();
        }
    }
}

