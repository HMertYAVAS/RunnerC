using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Rigidbody rb;
    public Animator anim;

    [SerializeField] float limitLeft = 11.6f;
    [SerializeField] float limitRight = 14.7f;

    public bool runBool;

    Vector3 mousePos;
    Vector3 onClickMousePos;
    public float moveSpeed;
    float mouseDeltaX;
    bool isClicked;
    int maxMouseDeltaX = 30;
    int controlSmoothing = 32;
    float sensivity = 0.01f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();

    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        PlayerMove();

    }



    void PlayerMove()
    {
        float xPos = transform.position.x - mouseDeltaX * sensivity;
        xPos = Mathf.Clamp(xPos, limitLeft, limitRight);

        UpdateMovement();

        if (runBool && !GameManager.instance.finish)
        {
            rb.MovePosition(new Vector3(xPos, transform.position.y, transform.position.z + moveSpeed * Time.deltaTime));
        }
        else
        {

        }

        //UpdateMovement();
        //    rb.MovePosition(new Vector3(xPos, transform.position.y, transform.position.z + -moveSpeed * Time.deltaTime));

    }

    private void UpdateMovement()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            if (!isClicked)
            {
                onClickMousePos = mousePos;


            }

            isClicked = true;
            runBool = true;
            anim.SetBool("run",true);
        }
        else if (isClicked)
        {


            isClicked = false;
        }
        mouseDeltaX = onClickMousePos.x - mousePos.x;
        mouseDeltaX = Mathf.Clamp(mouseDeltaX, -maxMouseDeltaX, maxMouseDeltaX);
        if (mouseDeltaX == maxMouseDeltaX)
        {
            onClickMousePos.x = mousePos.x + maxMouseDeltaX; //if value is clamp value, bring onclick mouse pos closer to mouse pos not to wait for clamped 2 value
        }
        if (mouseDeltaX == -maxMouseDeltaX)
        {
            onClickMousePos.x = mousePos.x - maxMouseDeltaX;
        }
        if (mouseDeltaX > 0.1f || mouseDeltaX < -0.1f)
            onClickMousePos = Vector3.Lerp(onClickMousePos, mousePos, Time.deltaTime * controlSmoothing);
        else
            mouseDeltaX = 0;
    }

}
