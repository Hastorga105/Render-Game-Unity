using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;


public class AnimController : MonoBehaviour
{
    Animator m_Animator;
    public PlayerInput _playerInput;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        _playerInput = GetComponent<PlayerInput>();

    }

    void Update()
    {
        /*
        if (starterAssetsInputs.dance)
        {
            animator.Play("Dancing");
        }*/

       if (_playerInput.actions["Dance"].WasPressedThisFrame())
        {
            animator.Play("Dance Moves");
        }

        if (_playerInput.actions["Backflip"].WasPressedThisFrame())
        {
            animator.Play("Backflip");
        }
        
    }
}
