using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RdnUnityBase.Common;

namespace RdnUnityBase.Define
{

    public partial class BGM : Enumeration
    {
        public static BGM Ingame = new BGM(1, nameof(Ingame));
    }
}