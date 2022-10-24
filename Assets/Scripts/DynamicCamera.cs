using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    [Range(0,0.1f)]public float shake;
    public float maxPositionOffset;
    public float maxAngleOffset;
    // Start is called before the first frame update
    void Start()
    {
        maxPositionOffset = 2;
        maxAngleOffset = 2;
        shake = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.player.lives > 0)
        {
            Shake();
        }

    }

    void Shake()
    {
        // Shake is equal to the traum squared to give a smooth curve of shake
        shake = (GameManager.instance.distanceScrpt.getDistanceTraveled() * 0.001f);

        // Reset Camera rotation
        transform.eulerAngles = new Vector3(0, 0, 0);

        // Determine how much to offset the rotationa and translation
        float offsetAngle = maxAngleOffset * shake * Random.Range(-0.5f, 0.5f);
        float offsetX = maxPositionOffset * shake * Random.Range(-0.5f, 0.5f);
        float offsetY = maxPositionOffset * shake * Random.Range(-1.0f, 1.0f);

        // Get current state
        Vector3 currentCameraAngle = transform.eulerAngles;
        Vector3 currentCameraPosition = transform.position;

        //newY = transform.position.y;
        //Vector3 target = lockedCameraPostion;

        // Current state + shake
        Vector3 newCameraAngle = currentCameraAngle + new Vector3(0, 0, offsetAngle);
        Vector3 newCameraPosition = currentCameraPosition + new Vector3(offsetX, offsetY, 0);

        // Apply
        transform.position = newCameraPosition;
        transform.eulerAngles = newCameraAngle;
    }
}
