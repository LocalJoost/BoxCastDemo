using HoloToolkit.Unity;
using UnityEngine;

namespace HoloToolkitExtensions.Utilities
{
    public class CameraMovementTracker : Singleton<CameraMovementTracker>
    {
        [SerializeField]
        private readonly float _sampleTime = 1.0f;
        private Vector3 _lastSampleLocation;
        private Quaternion _lastRotation;
        private float _lastTime;

        public float Speed { get; private set; }
        public float RotationDelta { get; private set; }
        public float Distance { get; private set; }

        void Start()
        {
            _lastTime = Time.time;
            _lastSampleLocation = CameraCache.Main.transform.position;
            _lastRotation = CameraCache.Main.transform.rotation;
        }

        void Update()
        {
            if (Time.time - _lastTime > _sampleTime)
            {
                Speed = CalculateSpeed();
                RotationDelta = CalculateRotation();
                Distance = CalculateDistanceCovered();
                _lastTime = Time.time;
                _lastSampleLocation = CameraCache.Main.transform.position;
                _lastRotation = CameraCache.Main.transform.rotation;
            }
        }

        private float CalculateSpeed()
        {
            // return speed in km/h
            return CalculateDistanceCovered() / (Time.time - _lastTime) * 3.6f;
        }

        private float CalculateDistanceCovered()
        {
            return Vector3.Distance(_lastSampleLocation,CameraCache.Main.transform.position);
        }

        private float CalculateRotation()
        {
            return Mathf.Abs(Quaternion.Angle(_lastRotation, CameraCache.Main.transform.rotation));
        }
    }
}
