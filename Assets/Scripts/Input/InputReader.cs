using System.Diagnostics;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private bool _isJump;
    private bool _isAbilityActive;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
            _isJump = true;

        if (Input.GetKeyUp(KeyCode.E))
            _isAbilityActive = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    public bool GetIsAbilityActive() => GetBoolAsTrigger(ref _isAbilityActive);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}