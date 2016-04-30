﻿using AspectInjector.Broker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FomodInfrastructure.Aspect
{
    
    public class AcpectDebugLoger
    {
        [Advice(InjectionPoints.After, InjectionTargets.Setter)]
        public void AfterSetLog([AdviceArgument(AdviceArgumentSource.Instance)] object Inst, [AdviceArgument(AdviceArgumentSource.TargetName)] string propertyName, [AdviceArgument(AdviceArgumentSource.TargetValue)] object value)
        {
            //Debug.Print($"Set ");
            Debug.Print($"{Inst.GetType().Name} Set {propertyName} = {value} [{value?.GetHashCode()}]");
        }

        [Advice(InjectionPoints.After, InjectionTargets.Getter)]
        public void AfterGetLog([AdviceArgument(AdviceArgumentSource.Instance)] object Inst, [AdviceArgument(AdviceArgumentSource.TargetName)] string propertyName, [AdviceArgument(AdviceArgumentSource.TargetValue)] object value)
        {
            //Debug.Print($"Get ");
            Debug.Print($"{Inst.GetType().Name} Get {propertyName} = {value} [{value?.GetHashCode()}]");
        }
    }
}
