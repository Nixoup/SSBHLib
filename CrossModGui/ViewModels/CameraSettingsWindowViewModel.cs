﻿using System.ComponentModel;

namespace CrossModGui.ViewModels
{
    public class CameraSettingsWindowViewModel : ViewModelBase
    {
        public float PositionX { get; set; }

        public float PositionY { get; set; }

        public float PositionZ { get; set; }

        public float RotationXDegrees { get; set; }

        public float RotationYDegrees { get; set; }

        public float RotationZDegrees { get; set; }
    }
}