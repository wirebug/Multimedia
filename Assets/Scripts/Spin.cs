using UnityEngine;
using System.Collections;

/// <summary>
/// Spin the object at a specified speed
/// </summary>
public class Spin : MonoBehaviour {
	[Tooltip("Spin: Yes or No")]
	public bool SelfSpin;
	[Tooltip("Spin the parent object instead of the object this script is attached to")]
	public bool SpinAroundParent;
	public float SelfSpinSpeed = 10f;
    public float ParentSpinSpeed = 10f;

	[HideInInspector]
	public bool clockwise = true;
	[HideInInspector]
	public float direction = 1f;
	[HideInInspector]
	public float directionChangeSpeed = 2f;

	// Update is called once per frame
	void Update() {
		if (direction < 1f) {
			direction += Time.deltaTime / (directionChangeSpeed / 2);
		}

		if (SelfSpin)
        {
			if (clockwise)
            {
					transform.Rotate(Vector3.up, (SelfSpinSpeed * direction) * Time.deltaTime);
			}
            else
            {
					transform.Rotate(-Vector3.up, (SelfSpinSpeed * direction) * Time.deltaTime);
			}
		}

        if (SpinAroundParent)
        {
            if (clockwise)
            {
                transform.parent.transform.Rotate(Vector3.up, (ParentSpinSpeed * direction) * Time.deltaTime);
            }
            else
            {
                transform.parent.transform.Rotate(-Vector3.up, (ParentSpinSpeed * direction) * Time.deltaTime);
            }
        }
    }
}