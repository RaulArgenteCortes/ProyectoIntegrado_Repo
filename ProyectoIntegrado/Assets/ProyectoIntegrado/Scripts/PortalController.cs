using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] Transform destination;

    public Transform GetDestination()
    {
        return destination;
    }
}
