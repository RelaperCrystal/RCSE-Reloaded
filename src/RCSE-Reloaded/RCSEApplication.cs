// RelaperCrystal's Simple Editor
// Copyright (C) RelaperCrystal and contributors 2020.

using CrystalEngine.Launcher;

namespace RCSE_Reloaded
{
    public class RCSEApplication : IApplication
    {
        public IMainForm StartForm { get; set; }

        public RCSEApplication()
        {
            
        }

        public void End()
        {
            
        }

        public void Launching(string[] args)
        {
            MainFrm.ParseArgsAndRun(args);
        }

        public void Start()
        {
            
        }
    }
}
