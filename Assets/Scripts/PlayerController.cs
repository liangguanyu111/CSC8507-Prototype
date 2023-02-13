using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float currentVelocity;
    public float smoothTime = 0.2f;
    public float walkSpeed = 2f;
    public float jumpForce;

    public Transform groundCheck;

    private Animator ac;
    private Transform cameraTransform;
    private Rigidbody rb;

    public bool isGround;
    private CapsuleCollider capsuleCollider;

    private int weaponLevel = 1;

    public Weapon[] weaponList;
    private void Start()
    {
        ac = this.GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        Cursor.visible = false;
    }


    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector2 inputDir = input.normalized;

        float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg +cameraTransform.eulerAngles.y;

        transform.eulerAngles = new Vector3(0, cameraTransform.eulerAngles.y, 0);

        if (inputDir!=Vector2.zero)
        {

            Vector3 moveDir = inputDir.x * transform.right + input.y * transform.forward;
            //transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref currentVelocity, smoothTime);

            rb.MovePosition(transform.position + moveDir.normalized * Time.deltaTime * walkSpeed);

            ac.SetBool("Move", true);
        }
        else
        {
            ac.SetBool("Move", false);
        }

        Vector3 startPoint = groundCheck.transform.position + new Vector3(0, 0.25f, 0);
        Vector3 endPoint = groundCheck.transform.position +new Vector3(0, 1.4f, 0);
        Collider[] colliders = Physics.OverlapCapsule(startPoint, endPoint,0.5f,LayerMask.GetMask("Ground"));

       if(colliders.Length!=0)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&isGround)
        {
            Debug.Log("Jump");
            rb.AddForce(Vector3.up * jumpForce);
        }

        PressWeapon PW;

        if (weaponList[weaponLevel - 1].TryGetComponent<PressWeapon>(out PW))
        {
          if(Input.GetMouseButtonDown(0))
            {
                PW.fire = true;
            }
          else if(Input.GetMouseButtonUp(0))
            {
                PW.fire = false;
            }

        }
        else if (Input.GetMouseButtonDown(0))
        {
            weaponList[weaponLevel - 1].Fire();
        }
    }
    private void FixedUpdate()
    {
  
    }

    public void WeaonUp()
    {
        weaponList[weaponLevel - 1].gameObject.SetActive(false);
        weaponLevel++;
        weaponList[weaponLevel - 1].gameObject.SetActive(true);
        ac.SetFloat("Blend", weaponLevel * 0.33f);
       
    }
}
