using HGrandry.Build;
using UnityEditor;

namespace HGrandry.Samples
{
    public class BuildMenu
    {
        // Build and Run
                
        [MenuItem("Build/Build and Run (release)")]
        public static void BuildAndRunRelease()
        {
            Build(EditorUserBuildSettings.activeBuildTarget, debug: false, run: true);
        }
        
        [MenuItem("Build/Build and Run (debug)")]
        public static void BuildAndRunDebug()
        {
            Build(EditorUserBuildSettings.activeBuildTarget, debug: true, run: true);
        }
        
        // build

        private static void Build(BuildTarget target, bool debug, bool run)
        {
            var builder = new CmdoDefaultBuilder();
            builder.Build(target, debug, run);
        }
    }
}