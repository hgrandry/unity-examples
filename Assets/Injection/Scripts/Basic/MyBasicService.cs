using HGrandry.Injection;
using UnityEngine;

namespace Basic
{
    // We extend Injectable so the service auto register on enabled.
    public class MyBasicService : Injectable<MyBasicService>
    {
        public void DoStuff()
        {
        }
    }
}