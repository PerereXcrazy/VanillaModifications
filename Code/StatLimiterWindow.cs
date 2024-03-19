using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ReflectionUtility;

namespace VanillaModifications
{
    class StatLimiter : MonoBehaviour
    {
        private static List<string> currentStats;

        public static void init()
        {
            BaseStatAsset attack_speed = AssetManager.base_stats_library.get("attack_speed");
            attack_speed.id = S.attack_speed;
            attack_speed.normalize = true;
            attack_speed.normalize_max = 666;
        }
    }
}