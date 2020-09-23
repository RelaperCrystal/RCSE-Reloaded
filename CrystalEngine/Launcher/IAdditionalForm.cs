// CrystalEngine
// Copyright (C) RelaperCrystal 2020

namespace CrystalEngine.Launcher
{
    public interface IAdditionalForm
    {
        void Initialize();
        string Information { get; set; }
        string Caption { get; set; }
    }
}
