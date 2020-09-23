// CrystalEngine
// Copyright (C) RelaperCrystal 2020

using System;

namespace CrystalEngine.Launcher
{
    public interface IMainForm
    {
        void Start();
        bool CanExit { get; }
        void Exit();
        void LaunchWithArgs(string[] args);
        void ExceptionOccoured(Exception ex);
        
    }
}
