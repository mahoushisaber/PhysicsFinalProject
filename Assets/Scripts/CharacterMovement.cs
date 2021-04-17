using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    public PhysicsEngine physicsEngineScript;
    private Vector3 rotation;

    public void Update()
    {
        float angularVelocityOnBody = physicsEngineScript.wOmega;
        this.rotation = new Vector3(0, angularVelocityOnBody * Time.deltaTime, 0);

       // Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
       //move = this.transform.TransformDirection(move);
        //_controller.Move(move * _speed);
        this.transform.Rotate(this.rotation);

    }
}
