using System;

namespace ClimateControlSystem.Domain
{
    public interface ICloseWindows
    {
        Action Close { get; set; }
    }
}