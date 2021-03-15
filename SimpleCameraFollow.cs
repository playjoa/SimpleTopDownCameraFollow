using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoMilone
{
    public class SimpleCameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform player_Target;

        [SerializeField]
        private float smoothTime = 0.125f, maxSpeed = 50;

        [Tooltip("Offset from player position!")]
        [SerializeField]
        private Vector3 offset = new Vector3(0, -15, -15);

        private Vector3 camVelo;

        void Follow()
        {
            if (!player_Target.gameObject.activeSelf || player_Target == null)
                return;


            //Tweak offset during play time to better find a optimal position

            //Calculating position to move to
            Vector3 desiredPosition = player_Target.position + offset;

            //Smooth out movement
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref camVelo, smoothTime, maxSpeed, Time.fixedDeltaTime);
            
            //Move to position
            transform.position = smoothedPosition;
        }

        void FixedUpdate()
        {
           Follow();
        }
    }
}
