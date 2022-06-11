using UnityEngine;

namespace Assets.Scripts
{
     class LookAtCamera : MonoBehaviour
    {

        [SerializeField] Camera camera;

        public bool justY = false;

        public void Start()
        {
            if (camera == null)
                camera = Camera.main;

            Vector3 originalRotation = camera.transform.rotation.eulerAngles;

            transform.LookAt(camera.transform);
            /*if (justY)
            {
                originalRotation.y = transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Euler(originalRotation);
            }*/
        }

    }
}
