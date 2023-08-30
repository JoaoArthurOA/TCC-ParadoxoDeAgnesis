using UnityEngine.InputSystem;
using UnityEngine;
using Cinemachine;
public class MudaCamera : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
   
   private InputAction aimAction;

   private void Awake()
   {
     aimAction = playerInput.actions["Aim"];
   }
}
