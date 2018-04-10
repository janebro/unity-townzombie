﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    [SerializeField] private float moveSpeed = 100;
    [SerializeField] private float turnSpeed = 5f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        //PUT BETTER LOGIC HERE!

        #region 
        /* THIS IS THE FIRST LEARNING PART FOR MOVEMENT. UP THERE IS A 3RD PERSON BETTER LOGIC! */
        characterController.SimpleMove(movement * moveSpeed * Time.deltaTime);

        animator.SetFloat("Speed", movement.magnitude);

        if (movement.magnitude > 0)
        {
            Quaternion newDirection = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        }
        #endregion
    }
}
