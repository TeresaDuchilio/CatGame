using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MoveObjectEvent : UnityEvent<Vector3, float, string> { }
