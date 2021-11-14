using ShalomeTestProject.Debugging;

namespace ShalomeTestProject
{
    public class ShalomeTestProjectConsts
    {
        public const string LocalizationSourceName = "ShalomeTestProject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ba46927aacb64014a3c8c87b6adf9177";
    }
}
