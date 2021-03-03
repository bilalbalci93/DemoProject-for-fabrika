using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fabrikademo.PlayerInput
{
    [CreateAssetMenu(menuName = "fabrikademo/Input/Input Data")]

    public class InputData : ScriptableObject
    {
        public float Horizontal;
        public float Vertical;

    }
}
