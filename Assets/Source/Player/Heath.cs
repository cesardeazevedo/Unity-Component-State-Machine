using UnityEngine;
using System.Collections;

public class Heath : MonoBehaviour
{

    public float heath = 100;

    public float maxHeath = 100;

    /// <summary>
    /// Determines whether the Heath is zero.
    /// </summary>
    /// <returns><c>true</c> if this instance is zero; otherwise, <c>false</c>.</returns>
    public bool IsZero()
    {
        return heath <= 0;
    }

    /// <summary>
    /// Determines whether the Heath is on max value.
    /// </summary>
    /// <returns><c>true</c> if this instance is max; otherwise, <c>false</c>.</returns>
    public bool IsMax()
    {
        return heath >= maxHeath;
    }

    /// <summary>
    /// Decrease the specified amount.
    /// </summary>
    /// <param name="amount">Amount.</param>
    public float Decrease(float amount)
    {
        if(!IsZero())
            heath -= amount;

        return heath;
    }

    /// <summary>
    /// Increase the specified amount.
    /// </summary>
    /// <param name="amount">Amount.</param>
    public float Increase(float amount)
    {
        if(!IsMax())
            heath += amount;

        return heath;
    }
}
