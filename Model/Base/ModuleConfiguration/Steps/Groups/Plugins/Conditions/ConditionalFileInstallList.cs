using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace FOMOD_Creator.Models.ModuleConfiguration.Steps.Groups.Plugins.Conditions
{
    /// <summary>
    /// A list of optional files that may optionally be installed for this module, base on condition flags.
    /// </summary>
    [Serializable]
    public class ConditionalFileInstallList
    {
        /// <summary>
        /// The list of patterns against which to match the conditional flags and installed files. All matching patterns will have their files installed.
        /// </summary>
        [XmlArray("patterns", Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("pattern", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public ConditionalInstallPattern[] Patterns { get; set; }
    }
}