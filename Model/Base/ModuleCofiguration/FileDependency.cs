using System;
using System.Xml.Serialization;
using AspectInjector.Broker;
using FomodInfrastructure.Aspect;
using FomodModel.Base.ModuleCofiguration.Enum;

namespace FomodModel.Base.ModuleCofiguration
{
    /// <summary>
    ///     A mod upon which the type of a Plugin depends.
    /// </summary>
    [Aspect(typeof (AspectINotifyPropertyChanged))]
    [Serializable]
    public class FileDependency
    {
        /// <summary>
        ///     The file of the mod upon which a the Plugin depends.
        /// </summary>
        [XmlAttribute("file")]
        public string File { get; set; }

        /// <summary>
        ///     The state of the mod file.
        /// </summary>
        [XmlAttribute("state")]
        public FileDependencyState State { get; set; }
    }
}