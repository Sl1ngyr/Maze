using UnityEngine;

namespace Player
{
    public class PlayerLook : MonoBehaviour
    {
        private const float CameraBorders = 80;

        [SerializeField] private Camera _camera;
        [SerializeField] private float _xSensitivity;
        [SerializeField] private float _ySensitivity;
        
        private float _xRotation = 0f;
        
        public void ProcessLook(Vector2 input)
        {
            float mouseX = input.x;
            float mouseY = input.y;
            //calculate camera rotation for looking up and down
            _xRotation -= (mouseY * Time.deltaTime) * _ySensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -CameraBorders, CameraBorders);

            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            //rotate player to look left and right
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSensitivity);
        }
    }
}