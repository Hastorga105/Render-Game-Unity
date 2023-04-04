using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnOff : MonoBehaviour
{
    private class BoneTransform
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
    }


    [SerializeField] GameObject player;
    public BoxCollider mainCollider;
    public GameObject ThisGuysRig;
    public Animator ThisGuysAnimator;

    //Get Up
    private Vector3 hipsPosition;
    public Transform hips;
    private Quaternion[] rotations;


    void Awake()
    {
        hips = ThisGuysAnimator.GetBoneTransform(HumanBodyBones.Hips);
    }

    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("start");
        GetRagdollBits();
        RagdollModeOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "meleeImpact")
        {
            RagdollModeOn();
        }

        

    }

    private void OnCollissionEnter(Collision collision)
    {
        Debug.Log("Pressed primary button.");
        if (collision.gameObject.tag == "Mytag")
        {
            RagdollModeOn();
        }
        
    }

    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidbodies;
    
    void GetRagdollBits()
    {
        Debug.Log("getragdollbits");
        ragDollColliders = ThisGuysRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = ThisGuysRig.GetComponentsInChildren<Rigidbody>();
    }

    void RagdollModeOn()
    {
        ThisGuysAnimator.enabled = false;
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
            rigid.AddForce(player.transform.forward * 20f, ForceMode.Impulse);
        }

        
        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(Test());
        
        
    }
    void RagdollModeOff()
    {
        Debug.Log("ragdoll off");
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }

        ThisGuysAnimator.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }


    IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
        AlignPositionToHips();
        ThisGuysAnimator.Play("StandUp");
        RagdollModeOff();
    }

    private void AlignPositionToHips()
    {
        Vector3 originalHipsPosition = hips.position;
        transform.position = hips.position;

        //Comprobar que estamos en el suelo
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo))
        {
            transform.position = new Vector3(transform.position.x, hitInfo.point.y, transform.position.z);
        }

        hips.position = originalHipsPosition;

    }

}
