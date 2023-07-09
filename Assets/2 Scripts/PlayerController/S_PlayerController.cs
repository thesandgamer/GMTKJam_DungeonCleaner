using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_PlayerController : MonoBehaviour
{
   private PlayerInputs playerInputs;
   
   public Vector2 moveValue { get; private set; }

   private bool moveKeyPressed = false;

   public bool immobilise = false;

   #region Events

   public event Action ev_StartMoving;
   public event Action<Vector2> ev_Move;
   public event Action ev_StopMoving;

   public event Action ev_StartInteract;
   public event Action ev_Interact;
   public event Action ev_StopInteract;

   public event Action ev_SwitchForm;
   

   #endregion
   private void Awake()
   {
      playerInputs = new PlayerInputs();
      
      playerInputs.CharacterControls.Move.started += context => StartMoving();
      playerInputs.CharacterControls.Move.canceled += context => StopMoving();

      playerInputs.CharacterControls.Interact.started += context => ev_StartInteract?.Invoke();
      playerInputs.CharacterControls.Interact.canceled += context => ev_StopInteract?.Invoke();

      playerInputs.CharacterControls.Interact.performed += context => Interact();
      
      playerInputs.CharacterControls.Switch.performed += context => SwichForm();
      
      

   }

   private void SwichForm()
   {
      if (immobilise) return;
      ev_SwitchForm?.Invoke();
   }

   private void StartMoving()
   {
      if (immobilise) return;

      ev_StartMoving?.Invoke();
      moveKeyPressed = true;
      moveValue = playerInputs.CharacterControls.Move.ReadValue<Vector2>();
   }

   private void StopMoving()
   {
      if (immobilise) return;

      ev_StopMoving?.Invoke();
      moveKeyPressed = false;
      moveValue = playerInputs.CharacterControls.Move.ReadValue<Vector2>();
   }

   private void Interact()
   {
      if (immobilise) return;

      ev_Interact?.Invoke();
   }

   private void FixedUpdate()
   {
      Move();
   }


   private void Move()
   {
      if (immobilise) return;

      moveValue = playerInputs.CharacterControls.Move.ReadValue<Vector2>();
      ev_Move.Invoke(moveValue);
   }
   private void OnEnable()
   {
      playerInputs.Enable();
   }

   private void OnDisable()
   {
      playerInputs.Disable();
   }
   
}
