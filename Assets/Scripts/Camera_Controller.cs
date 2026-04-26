using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // if we want up and down panning
    // float rotationX = 0f;
    float rotationY = 0f;
    GameObject playerCharacter;

    public float sensitivity = 15f;
    public float maxLeftRotate = -45f;
    public float maxRightRotate = 45f;

    void Start()
    {
        playerCharacter = GameObject.Find("Player");
    }

    // void Update()
    // {
        
    //     if (maxLeftRotate >= rotationY && rotationY <= maxRightRotate)
    //     {
    //         rotationY += Input.GetAxis("Mouse X") * sensitivity;
    //         transform.localEulerAngles = new Vector3(0, rotationY, 0);
    //     }
    //     else if (maxLeftRotate >= rotationY || rotationY <= maxRightRotate)
    //     {
    //         playerCharacter.transform.Rotate(0, rotationY, 0);
    //     }
    //     // for up and down transform
    //     // rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
    //     // transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    // }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        rotationY += mouseX;

        // Clamp rotation
        float clampedRotation = Mathf.Clamp(rotationY, maxLeftRotate, maxRightRotate);

        // If inside limits → rotate camera
        if (rotationY >= maxLeftRotate && rotationY <= maxRightRotate)
        {
            transform.localEulerAngles = new Vector3(0, clampedRotation, 0);
        }
        else
        {
            // Outside limits → rotate player instead
            playerCharacter.transform.Rotate(0, mouseX, 0);

            // Keep camera at the edge
            rotationY = clampedRotation;
            transform.localEulerAngles = new Vector3(0, clampedRotation, 0);
        }
    }
}