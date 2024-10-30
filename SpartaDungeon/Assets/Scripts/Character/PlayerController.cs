using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpForce;
    public LayerMask groundLayerMask;
    private Rigidbody rigidbody;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;

    public Interaction interaction;

    private Coroutine buff;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        interaction = GetComponent<Interaction>();
    }

    void Start()
    {
        CharacterManager.Instance.Player.useItem += ChangeStatByItem;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidbody.velocity.y;
        rigidbody.velocity = dir;
    }

    private void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGround())
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            interaction.UseItem();
        }
    }

    bool IsGround()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.1f), Vector3.down)
        };

        for(int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }

    public void ChangeStatByItem()
    {
        Debug.Log("실행했냐2");
        if (CharacterManager.Instance.Player.itemData.Type == ItemType.Consumable)
        {
            foreach (ItemDataConsumable itemDataConsumable in CharacterManager.Instance.Player.itemData.consumables)
            {
                if (itemDataConsumable.type == ConsumableType.Speed)
                {
                    if(buff != null)
                    {
                        StopCoroutine(buff);
                    }
                    buff = StartCoroutine(Buff(itemDataConsumable.value, itemDataConsumable.duration));
                }
            }
        }
    }

    private IEnumerator Buff(float buffAmount, float duration)
    {
        moveSpeed += buffAmount;

        yield return new WaitForSeconds(buffAmount);

        moveSpeed -= buffAmount;
    }
}
