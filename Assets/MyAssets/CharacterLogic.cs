using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class CharacterLogic : MonoBehaviour
{
    public float x, y;

    //public RigidBody rb;
    public bool attack;
    public bool goForward;
    public bool meleeBoost;
    public BoxCollider handBoxCol;

    public PlayerInput _playerInput;
    private StarterAssetsInputs starterAssetsInputs;

    private Animator animator;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        _playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        //starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    // Start is called before the first frame update
    void Start()
    {
        DeactivateCollider();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (goForward)
        {
            //rb.velocity = transform.forward * meleeBoost;
        }
    }
    void Update()
    {
        if (_playerInput.actions["Attack"].WasPressedThisFrame())
        {
            animator.Play("Dance Moves");
            animator.SetTrigger("Punching");
            attack = true;
        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Pressed primary button.");
            animator.SetTrigger("Punching");
            attack = true;
            //ActivateCollider();

        }*/
            

    }

    public void ActivateCollider()
    {
        handBoxCol.enabled = true;
    }
    public void DeactivateCollider()
    {
        handBoxCol.enabled = false;
    }

    public void StopPunching()
    {
        attack = false;
        goForward= false;
        DeactivateCollider();
    }

    public void GoForward()
    {
        goForward = true;
    }


}
