using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;

    public Transform cameraTransform;
    public float mouseSensitivity = 100f;

    private Rigidbody rb;
    private Vector3 movementInput;
    private Vector3 moveDirection;
    private float cameraPitch = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita que o Rigidbody gire automaticamente.
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela.
    }

    void Update()
    {
        // Captura o movimento do mouse para controlar a câmera.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -45f, 45f);

        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Captura as entradas do teclado ou do joystick.
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementInput = new Vector3(horizontal, 0f, vertical).normalized;

        // Calcula a direção do movimento baseada na câmera.
        if (movementInput.magnitude >= 0.1f)
        {
            moveDirection = cameraTransform.forward * movementInput.z + cameraTransform.right * movementInput.x;
            moveDirection.y = 0f;
            moveDirection.Normalize();
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        // Aplica o movimento ao Rigidbody.
        Vector3 velocity = moveDirection * moveSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }
}