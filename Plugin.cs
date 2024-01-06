using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Core.Logging.Interpolation;
using BepInEx.Logging;
using UnityEngine;

namespace FPSUnlock.Redux
{
    // Token: 0x02000003 RID: 3
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        private void StoreModId()
        {
            ConfigEntry<int> configEntry = base.Config.Bind<int>("Developer", "NexusID", PluginInfo.nexusId, "nexus mod id -- automatically generated -- cannot be changed");
            if (configEntry.Value != 312)
            {
                configEntry.Value = 312;
                base.Config.Save();
            }
        }
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        private void Awake()
        {
            Logger.LogInfo(Plugin.Log);
            ManualLogSource log = Plugin.Log;
            bool flag;
            BepInExInfoLogInterpolatedStringHandler bepInExInfoLogInterpolatedStringHandler = new BepInExInfoLogInterpolatedStringHandler(14, 0, out flag);
            if (flag)
            {
                bepInExInfoLogInterpolatedStringHandler.AppendLiteral("Plugin loaded!");
            }
            log.LogInfo(bepInExInfoLogInterpolatedStringHandler);
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002098 File Offset: 0x00000298
        private void Start()
        {
            this.StoreModId();
            Application.targetFrameRate = -1;
            QualitySettings.vSyncCount = 0;
            ManualLogSource logger = base.Logger;
            bool flag;
            BepInExInfoLogInterpolatedStringHandler bepInExInfoLogInterpolatedStringHandler = new BepInExInfoLogInterpolatedStringHandler(20, 0, out flag);
            if (flag)
            {
                bepInExInfoLogInterpolatedStringHandler.AppendLiteral("Target Fps set to -1");
            }
            logger.LogInfo(bepInExInfoLogInterpolatedStringHandler);
        }

        // Token: 0x04000004 RID: 4
        internal static ManualLogSource Log = new ManualLogSource("FPSUnlock.Redux");
    }
}
