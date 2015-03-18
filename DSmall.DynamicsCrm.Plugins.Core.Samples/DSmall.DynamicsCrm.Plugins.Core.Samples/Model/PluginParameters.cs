namespace DSmall.DynamicsCrm.Plugins.Core.Samples.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>The plugin parameters.</summary>
    [Serializable]
    public class PluginParameters
    {
        /// <summary>Gets or sets the input parameters.</summary>
        public List<ParameterDetail> InputParameters { get; set; }

        /// <summary>Gets or sets the output parameters.</summary>
        public List<ParameterDetail> OutputParameters { get; set; }

        /// <summary>Gets or sets the pre entity images.</summary>
        public List<ParameterDetail> PreEntityImages { get; set; }

        /// <summary>Gets or sets the post entity images.</summary>
        public List<ParameterDetail> PostEntityImages { get; set; }
    }
}