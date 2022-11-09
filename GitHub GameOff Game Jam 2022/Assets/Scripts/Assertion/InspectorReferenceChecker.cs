using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Allows you to specify objects that you want asserted to not-null.
/// At Awake(), every reference will be asserted.
/// </summary>
/// <author>Gino</author>
public abstract class InspectorReferenceChecker : MonoBehaviour
{
    private void Awake()
    {
        foreach (var reference in CheckForMissingReferences())
        {
            Assert.IsNotNull(reference);
        }
    }

    /// <summary>
    /// Pass any number of objects that you want asserted to not-null
    /// </summary>
    /// <returns>An array of objects</returns>
    /// <example>
    /// protected override object[] CheckForMissingReferences() => new object[] 
    /// {
    ///     myAnimator, myText, ...
    /// };
    /// </example>
    protected abstract object[] CheckForMissingReferences();

}
