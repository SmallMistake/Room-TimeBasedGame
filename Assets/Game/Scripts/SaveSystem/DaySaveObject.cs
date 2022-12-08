using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    /// <summary>
	/// A serializable entity to store progress made in a day, if it's been complete and if any other data needs to be saved
	/// </summary>
    [System.Serializable]
    public class DaySaveObject
    {
        public bool DayComplete = false;
    }
}