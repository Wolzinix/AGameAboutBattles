using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _MovementAction;
    [SerializeField] private float MovementSpeed = 1;
    [SerializeField] private float xPositif;
    [SerializeField] private float xNegatif;

    void Update()
    {
        float x = _MovementAction.action.ReadValue<Vector2>().x;
        float movement =  x * Time.deltaTime * MovementSpeed;
        MoveCamera(movement);
    }
    private void MoveCamera(float coord)
    {
        if(CameraBorder(transform.position.z + coord))
        {
            transform.position = new Vector3(
            transform.position.x
            , transform.position.y
            , transform.position.z + coord);
        }
    }
    private bool CameraBorder(float coord)
    {
        return coord < xPositif && coord > xNegatif;
    }
}