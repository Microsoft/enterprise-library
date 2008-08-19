//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Cryptography Application Block
//===============================================================================
// Copyright � Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System.Collections.Generic;
using System.Configuration;
using System.Management.Instrumentation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Manageability;

namespace Microsoft.Practices.EnterpriseLibrary.Security.Cryptography.Configuration.Manageability
{
    /// <summary>
    /// Represents the configuration information from a 
    /// <see cref="Microsoft.Practices.EnterpriseLibrary.Security.Cryptography.Configuration.CustomHashProviderData"/> instance.
    /// </summary>
    /// <seealso cref="Microsoft.Practices.EnterpriseLibrary.Security.Cryptography.Configuration.CustomHashProviderData"/>
    /// <seealso cref="NamedConfigurationSetting"/>
    /// <seealso cref="ConfigurationSetting"/>
    [ManagementEntity]
    public partial class CustomHashProviderSetting : HashProviderSetting
    {
        string[] attributes;
        string providerType;

        /// <summary>
        /// Initialize a new instance of the <see cref="CustomHashProviderSetting"/> class with a source element, 
        /// name of the provider, the provider type and the provider attributes.
        /// </summary>
        /// <param name="sourceElement">The source element.</param>
        /// <param name="name">The name of the provider.</param>
        /// <param name="providerType">The provider type.</param>
        /// <param name="attributes">The attributes for the provider.</param>
        public CustomHashProviderSetting(CustomHashProviderData sourceElement,
                                         string name,
                                         string providerType,
                                         string[] attributes)
            : base(sourceElement, name)
        {
            this.providerType = providerType;
            this.attributes = attributes;
        }

        /// <summary>
        /// Gets the collection of attributes for the custom hash provider represented as a 
        /// <see cref="string"/> array of key/value pairs for the represented configuration object.
        /// </summary>
        /// <seealso cref="Microsoft.Practices.EnterpriseLibrary.Security.Cryptography.Configuration.CustomHashProviderData.Attributes">
        /// CustomHashProviderData.Attributes</seealso>
        [ManagementConfiguration]
        public string[] Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }

        /// <summary>
        /// Gets the name of the type for the custom hash provider for the represented configuration object.
        /// </summary>
        /// <seealso cref="Microsoft.Practices.EnterpriseLibrary.Common.Configuration.NameTypeConfigurationElement.Type">Inherited NameTypeConfigurationElement.Type</seealso>
        [ManagementConfiguration]
        public string ProviderType
        {
            get { return providerType; }
            set { providerType = value; }
        }

        /// <summary>
        /// Returns the <see cref="CustomHashProviderSetting"/> instance corresponding to the provided values for the key properties.
        /// </summary>
        /// <param name="ApplicationName">The value for the ApplicationName key property.</param>
        /// <param name="SectionName">The value for the SectionName key property.</param>
        /// <param name="Name">The value for the Name key property.</param>
        /// <returns>The published <see cref="CustomHashProviderSetting"/> instance specified by the values for the key properties,
        /// or <see langword="null"/> if no such an instance is currently published.</returns>
        [ManagementBind]
        public static CustomHashProviderSetting BindInstance(string ApplicationName,
                                                             string SectionName,
                                                             string Name)
        {
            return BindInstance<CustomHashProviderSetting>(ApplicationName, SectionName, Name);
        }

        /// <summary>
        /// Returns an enumeration of the published <see cref="CustomHashProviderSetting"/> instances.
        /// </summary>
        [ManagementEnumerator]
        public static IEnumerable<CustomHashProviderSetting> GetInstances()
        {
            return GetInstances<CustomHashProviderSetting>();
        }

        /// <summary>
        /// Saves the changes on the <see cref="CustomHashProviderSetting"/> to its corresponding configuration object.
        /// </summary>
        /// <param name="sourceElement">The configuration object on which the changes must be saved.</param>
        /// <returns><see langword="true"/> if changes have been saved, <see langword="false"/> otherwise.</returns>
        protected override bool SaveChanges(ConfigurationElement sourceElement)
        {
            return CustomHashProviderDataWmiMapper.SaveChanges(this, sourceElement);
        }
    }
}