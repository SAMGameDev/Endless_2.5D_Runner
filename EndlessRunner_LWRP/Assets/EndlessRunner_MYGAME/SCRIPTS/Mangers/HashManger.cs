using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class HashManger : Singleton<HashManger>
    {
        public Dictionary<TranistionParemeters, int> DicMainParameters = new Dictionary<TranistionParemeters, int>();

        public void Awake()
        {
            TranistionParemeters[] arr = System.Enum.GetValues(typeof(TranistionParemeters)) as TranistionParemeters[];

            foreach(TranistionParemeters t in arr)
            {
                DicMainParameters.Add(t, Animator.StringToHash(t.ToString()));
            }
        }
    }
}

