using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_PlayerController : MonoBehaviour
{
   private PlayerInputs playerInputs;
   
   public Vector2 moveValue { get; private set; }

   private bool moveKeyPressed = false;

   #region Events

   public event Action ev_StartMoving;
   public event Action<Vector2> ev_Move;
   public event Action ev_StopMoving;
   

   #endregion
   private void Awake()
   {
      playerInputs = new PlayerInputs();
      
      playerInputs.CharacterControls.Move.started += context => StartMoving();
      playerInputs.CharacterControls.Move.canceled += context => StopMoving();

   }

   private void StartMoving()
   {
      ev_StartMoving?.Invoke();
      moveKeyPressed = true;
      moveValue = playerInputs.CharacterControls.Move.ReadValue<Vector2>();
   }

   private void StopMoving()
   {
      ev_StopMoving?.Invoke();
      moveKeyPressed = false;
      moveValue = playerInputs.CharacterControls.Move.ReadValue<Vector2>();
   }

   private void FixedUpdate()
   {
      Move();
   }


   private void Move()
   {
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
