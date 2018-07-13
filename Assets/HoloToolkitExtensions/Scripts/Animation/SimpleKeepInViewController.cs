using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkitExtensions.Utilities;

namespace HoloToolkitExtensions.Animation
{
    public class SimpleKeepInViewController : MonoBehaviour
    {
        [Tooltip("Max distance to display object before user")]
        public float MaxDistance = 2f;

        [Tooltip("Distance before the obstruction to keep the current object")]
        public float DistanceBeforeObstruction = 0.02f;

        [Tooltip("Layers to 'see' when detecting obstructions")]
        public int LayerMask = Physics.DefaultRaycastLayers;

        [Tooltip("Time before calculating a new position")]
        public float PollInterval = 2f;

        [SerializeField]
        private BaseRayStabilizer _stabilizer;

        [SerializeField]
        private bool _showDebugBoxcastLines = true;

        private float _lastPollTime;


        void Update()
        {
            if (Time.time > _lastPollTime)
            {
                _lastPollTime = Time.time + PollInterval;
                LeanTween.move(gameObject, GetNewPosition(), 0.5f).setEaseInOutSine();
            }
#if UNITY_EDITOR
            if (_showDebugBoxcastLines)
            {
                LookingDirectionHelpers.GetObjectBeforeObstruction(gameObject, MaxDistance,
                    DistanceBeforeObstruction, LayerMask, _stabilizer, true);
            }
#endif
        }

        private Vector3 GetNewPosition()
        {
            return LookingDirectionHelpers.GetObjectBeforeObstruction(gameObject, MaxDistance,
                DistanceBeforeObstruction, LayerMask, _stabilizer);
        }
    }
}

