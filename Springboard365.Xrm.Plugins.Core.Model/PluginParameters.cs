namespace Springboard365.Xrm.Plugins.Core.Model
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class PluginParameters
    {
        public List<ParameterDetail> InputParameters { get; set; }

        public List<ParameterDetail> OutputParameters { get; set; }

        public List<ParameterDetail> PreEntityImages { get; set; }

        public List<ParameterDetail> PostEntityImages { get; set; }
    }
}