using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gb.Logging
{
    public class Log
    {
        [RuntimeInitializeOnLoadMethod]
        static void OnRuntimeMethodLoad()
        {
            Debug.Log("After Scene is loaded and game is running from LogManager");
        }
    }
}