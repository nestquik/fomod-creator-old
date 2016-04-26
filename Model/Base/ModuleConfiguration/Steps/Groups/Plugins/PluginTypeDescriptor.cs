using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using FOMOD_Creator.Models.ModuleConfiguration.Dependencies;

namespace FOMOD_Creator.Models.ModuleConfiguration.Steps.Groups.Plugins
{
    /// <summary>
    /// Describes the type of a plugin.
    /// </summary>
    [Serializable]
    public class PluginTypeDescriptor
    {
        [XmlElement("dependencyType", typeof(DependencyPluginType), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("type", typeof(PluginType), Form = XmlSchemaForm.Unqualified)]
        public object Item { get; set; }
    }
}