using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;
using FOMOD_Creator.Models.ModuleConfiguration.Enums;

namespace FOMOD_Creator.Models.ModuleConfiguration.Steps.Groups.Plugins
{
    /// <summary>
    /// A list of plugins.
    /// </summary>
    [Serializable]
    public class PluginList
    {
        public PluginList()
        {
            Order = OrderEnum.Ascending;
        }

        /// <summary>
        /// A mod plugin belonging to a group.
        /// </summary>
        [XmlElement("plugin", Form = XmlSchemaForm.Unqualified)]
        public Plugin[] Plugin { get; set; }

        /// <summary>
        /// The order by which to list the plugins.
        /// </summary>
        [XmlAttribute("order")]
        [DefaultValue(OrderEnum.Ascending)]
        public OrderEnum Order { get; set; }
    }
}