using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class VehicleDynamics : MonoBehaviour
{
    private Vehicle vehicle;

    private float targetSpeed;
    private bool isLerpingSpeed;
    private float speedLerpTime;
    public float speedLerpDuration = 0.5f;  // Hız değişiminin süresi (yarım saniye)

    private float originalDistance;
    private float targetDistance;
    private bool isLerpingDistance;
    private float distanceLerpTime;
    public float distanceLerpDuration = 0.5f; // Mesafe değişiminin süresi (yarım saniye)

    private void Start()
    {
        vehicle = GetComponent<Vehicle>();
    }

    private void FixedUpdate()
    {
        if (vehicle == null) return;

        // Hız geçişini Lerp ile yap
        if (isLerpingSpeed)
        {
            speedLerpTime += Time.deltaTime / speedLerpDuration;
            vehicle.UpdateSpeed(Mathf.Lerp(vehicle.CurrentSpeed, targetSpeed, speedLerpTime));
            if (speedLerpTime >= 1f) isLerpingSpeed = false;
        }

        // Mesafe geçişini Lerp ile yap
        if (isLerpingDistance)
        {
            distanceLerpTime += Time.fixedDeltaTime / distanceLerpDuration;
            vehicle.distanceTravelled = Mathf.Lerp(originalDistance, targetDistance, distanceLerpTime);
            if (distanceLerpTime >= 1f) isLerpingDistance = false;
        }
    }

    public void StartDistanceLerp(float pushDistance)
    {
        originalDistance = vehicle.distanceTravelled;
        targetDistance = vehicle.distanceTravelled + pushDistance;
        isLerpingDistance = true;
        distanceLerpTime = 0f;
    }

    public void UpdateSpeed(float newSpeed)
    {
        targetSpeed = newSpeed;
        speedLerpTime = 0f;
        isLerpingSpeed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vehicle otherVehicle = collision.gameObject.GetComponent<Vehicle>();
        if (otherVehicle != null)
        {
            float speedDifference = vehicle.CurrentSpeed - otherVehicle.CurrentSpeed;

            if (speedDifference >= 0)
            {
                StartCoroutine(TemporarySpeedChange(vehicle.CurrentSpeed * 0.75f, 0.5f));  // %25 yavaşlat
                otherVehicle.GetComponent<VehicleDynamics>().StartCoroutine(otherVehicle.GetComponent<VehicleDynamics>().TemporarySpeedChange(otherVehicle.CurrentSpeed * 1.25f, 0.5f));  // %25 hızlandır
                StartDistanceLerp(-1f);  // Geride itiş
                otherVehicle.GetComponent<VehicleDynamics>().StartDistanceLerp(1f);  // İleri itiş
            }
            else
            {
                StartCoroutine(TemporarySpeedChange(vehicle.CurrentSpeed * 1.25f, 0.5f));  // %25 hızlandır
                otherVehicle.GetComponent<VehicleDynamics>().StartCoroutine(otherVehicle.GetComponent<VehicleDynamics>().TemporarySpeedChange(otherVehicle.CurrentSpeed * 0.75f, 0.5f));  // %25 yavaşlat
                StartDistanceLerp(1f);  // İleri itiş
                otherVehicle.GetComponent<VehicleDynamics>().StartDistanceLerp(-1f);  // Geride itiş
            }
        }
    }

    IEnumerator TemporarySpeedChange(float newSpeed, float duration)
    {
        float originalSpeed = vehicle.CurrentSpeed;
        targetSpeed = newSpeed;
        speedLerpTime = 0f;
        isLerpingSpeed = true;

        yield return new WaitForSeconds(duration);

        targetSpeed = originalSpeed;
        speedLerpTime = 0f;
        isLerpingSpeed = true;
    }
}
