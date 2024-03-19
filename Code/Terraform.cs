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
    class Terraform
    {
        public static void init()
        {

            TerraformOptions softlightning = new TerraformOptions();
            softlightning.id = "lightning_soft";
            softlightning.flash = true;
            softlightning.lightningEffect = true;
            softlightning.addBurned = true;
            softlightning.removeFrozen = true;
            softlightning.addHeat = 1;
            AssetManager.terraform.add(softlightning);

            TerraformOptions softfire = new TerraformOptions();
            softfire.id = "fire_soft";
            softfire.damageBuildings = true;
            softfire.flash = true;
            softfire.explosion_pixel_effect = true;
            softfire.addBurned = true;
            softfire.removeFrozen = true;
            softfire.setFire = true;
            AssetManager.terraform.add(softfire);
        }
    }
}
