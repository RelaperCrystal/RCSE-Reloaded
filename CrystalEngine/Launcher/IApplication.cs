// CrystalEngine
// Copyright (C) RelaperCrystal 2020

namespace CrystalEngine.Launcher
{
    public interface IApplication
    {
        IMainForm StartForm { get; set; }
        void Start();
        void End();
        void Launching(string[] args);
    }
}
