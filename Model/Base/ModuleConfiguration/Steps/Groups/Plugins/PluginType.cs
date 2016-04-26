using System;
using System.Xml.Serialization;
using FOMOD_Creator.Models.ModuleConfiguration.Enums;

namespace FOMOD_Creator.Models.ModuleConfiguration.Steps.Groups.Plugins
{
    /// <summary>
    /// The type of a given plugin.
    /// </summary>
    [Serializable]
    public class PluginType
    {
        /// <summary>
        /// The name of the plugin type.
        /// </summary>
        [XmlAttribute("name")]
        public PluginTypeEnum Name { get; set; }
    }
}