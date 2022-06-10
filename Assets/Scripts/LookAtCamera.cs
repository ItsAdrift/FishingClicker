using UnityEngine;

namespace Assets.Scripts
{
     class LookAtCamera : MonoBehaviour
    {

        public void Start()
        {
            transform.LookAt(Camera.main.transform);
        }

    }
}
