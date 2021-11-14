using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ShalomeTestProject.Localization
{
    public static class ShalomeTestProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ShalomeTestProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ShalomeTestProjectLocalizationConfigurer).GetAssembly(),
                        "ShalomeTestProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
