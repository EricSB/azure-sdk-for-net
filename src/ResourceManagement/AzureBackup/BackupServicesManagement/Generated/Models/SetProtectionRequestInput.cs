// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;
using Microsoft.Azure.Management.BackupServices.Models;

namespace Microsoft.Azure.Management.BackupServices.Models
{
    /// <summary>
    /// The definition of a SetProtectionRequestInput Object.
    /// </summary>
    public partial class SetProtectionRequestInput : ManagementBaseObject
    {
        private string _policyId;
        
        /// <summary>
        /// Required. PolicyId for protection.
        /// </summary>
        public string PolicyId
        {
            get { return this._policyId; }
            set { this._policyId = value; }
        }
        
        private IList<string> _protectableObjects;
        
        /// <summary>
        /// Required. ProtectableObjects  for setting protection.
        /// </summary>
        public IList<string> ProtectableObjects
        {
            get { return this._protectableObjects; }
            set { this._protectableObjects = value; }
        }
        
        private string _protectableObjectType;
        
        /// <summary>
        /// Required. ProtectableObject type setting protection.
        /// </summary>
        public string ProtectableObjectType
        {
            get { return this._protectableObjectType; }
            set { this._protectableObjectType = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the SetProtectionRequestInput class.
        /// </summary>
        public SetProtectionRequestInput()
        {
            this.ProtectableObjects = new LazyList<string>();
        }
        
        /// <summary>
        /// Initializes a new instance of the SetProtectionRequestInput class
        /// with required arguments.
        /// </summary>
        public SetProtectionRequestInput(List<string> protectableObjects, string protectableObjectType, string policyId)
            : this()
        {
            if (protectableObjects == null)
            {
                throw new ArgumentNullException("protectableObjects");
            }
            if (protectableObjectType == null)
            {
                throw new ArgumentNullException("protectableObjectType");
            }
            if (policyId == null)
            {
                throw new ArgumentNullException("policyId");
            }
            this.ProtectableObjects = protectableObjects;
            this.ProtectableObjectType = protectableObjectType;
            this.PolicyId = policyId;
        }
    }
}
