using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Faker.Solution.Localization
{
    public static class SolutionLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SolutionConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SolutionLocalizationConfigurer).GetAssembly(),
                        "Faker.Solution.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
