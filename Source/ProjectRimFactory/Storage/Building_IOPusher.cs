﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using UnityEngine;

namespace ProjectRimFactory.Storage
{
    public class Building_IOPusher : Building_StorageUnitIOBase
    {

        public Building_IOPusher() : base(ContentFinder<Texture2D>.Get("Storage/CargoPlatform"), ContentFinder<Texture2D>.Get("PRFUi/IoIcon"))
        {
           

        }

        public override IntVec3 WorkPosition {
            get
            {
                return this.Position + this.Rotation.FacingCell;
            }
        
        }



        public override StorageIOMode IOMode { get => StorageIOMode.Output; set => _ = value; }

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            base.mode = IOMode;
        }
    }

    class PlaceWorker_IOPusherHilight : PlaceWorker
    {
        public override void DrawGhost(ThingDef def, IntVec3 center, Rot4 rot, Color ghostCol, Thing thing = null)
        {
           // base.DrawGhost(def, center, rot, ghostCol, thing);

            IntVec3 outputCell = center + rot.FacingCell;


            GenDraw.DrawFieldEdges(new List<IntVec3> { outputCell }, Common.CommonColors.outputCell);



        }
    }



}
