using System;
using System.Threading;
using NCMS;
using UnityEngine;
using ReflectionUtility;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ai;

namespace VanillaModifications
{
    [ModEntry]
    class Main : MonoBehaviour
    {
        void Awake()
        {
            Clouds.init();
            Drops.init();
            Resource.init();
            Items.init();
            Terraform.init();
            Kingdoms.init();
            Traits.init();
            Actors.init();
            StatLimiter.init();
            Projectiles.init();
            Effects.init();
            Status.init();
        }
    }
}