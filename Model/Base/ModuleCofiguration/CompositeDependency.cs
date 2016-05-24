using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;
using AspectInjector.Broker;
using FomodInfrastructure.Aspect;
using FomodModel.Base.ModuleCofiguration.Enum;

namespace FomodModel.Base.ModuleCofiguration
{
    //TODO удалить закоментированное после отладки

    /// <summary>
    ///     A dependency that is made up of one or more dependencies.
    /// </summary>
    [Aspect(typeof(AspectINotifyPropertyChanged))]
    [Serializable]
    public class CompositeDependency
    {
        CompositeDependency _dependencies;

        /// <summary>
        ///     CompositeDependency class constructor
        /// </summary>
        public CompositeDependency()
        {
            Operator = CompositeDependencyOperator.And;
        }

       
        [XmlElement("fileDependency", typeof(FileDependency))]
        public ObservableCollection<FileDependency> FileDependencies { get; set; }//= new ObservableCollection<FileDependency>();

        [XmlElement("flagDependency", typeof(FlagDependency))]
        public ObservableCollection<FlagDependency> FlagDependencies { get; set; } //= new ObservableCollection<FlagDependency>();

        [XmlElement("gameDependency", typeof(VersionDependency))]
        public VersionDependency GameVersionDependencies { get; set; }

        [XmlElement("fommDependency", typeof(VersionDependency))]
        public VersionDependency FommVersionDependencies { get; set; }

        [XmlElement("dependencies", typeof(CompositeDependency))]
        public CompositeDependency Dependencies
        {
            get { return _dependencies; }
            set
            {
                _dependencies = value;
                if (value != null)
                    value.Parent = this;
            }
        }
        
        /// <summary>
        ///     The relation of the contained dependencies.
        /// </summary>
        [XmlAttribute("operator")]
        //[DefaultValue(CompositeDependencyOperator.And)]
        public CompositeDependencyOperator Operator { get; set; }

        [XmlIgnore]
        public CompositeDependency Parent { get; set; }


        public static CompositeDependency Create()
        {
            return new CompositeDependency { Operator = CompositeDependencyOperator.And};
        }
    }
}