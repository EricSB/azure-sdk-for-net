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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Management.SiteRecovery
{
    public static partial class ProtectionContainerOperationsExtensions
    {
        /// <summary>
        /// Discovers a protectable item.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='fabricName'>
        /// Required. Fabric name.
        /// </param>
        /// <param name='protectionContainerName'>
        /// Required. Protection container name.
        /// </param>
        /// <param name='input'>
        /// Required. Discover Protectable Item Request.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse BeginDiscoverProtectableItem(this IProtectionContainerOperations operations, string fabricName, string protectionContainerName, DiscoverProtectableItemRequest input, CustomRequestHeaders customRequestHeaders)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IProtectionContainerOperations)s).BeginDiscoverProtectableItemAsync(fabricName, protectionContainerName, input, customRequestHeaders);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Discovers a protectable item.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='fabricName'>
        /// Required. Fabric name.
        /// </param>
        /// <param name='protectionContainerName'>
        /// Required. Protection container name.
        /// </param>
        /// <param name='input'>
        /// Required. Discover Protectable Item Request.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> BeginDiscoverProtectableItemAsync(this IProtectionContainerOperations operations, string fabricName, string protectionContainerName, DiscoverProtectableItemRequest input, CustomRequestHeaders customRequestHeaders)
        {
            return operations.BeginDiscoverProtectableItemAsync(fabricName, protectionContainerName, input, customRequestHeaders, CancellationToken.None);
        }
        
        /// <summary>
        /// Discovers a protectable item.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='fabricName'>
        /// Required. Fabric name.
        /// </param>
        /// <param name='protectionContainerName'>
        /// Required. Protection container name.
        /// </param>
        /// <param name='input'>
        /// Required. Discover Protectable Item Request.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static LongRunningOperationResponse DiscoverProtectableItem(this IProtectionContainerOperations operations, string fabricName, string protectionContainerName, DiscoverProtectableItemRequest input, CustomRequestHeaders customRequestHeaders)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IProtectionContainerOperations)s).DiscoverProtectableItemAsync(fabricName, protectionContainerName, input, customRequestHeaders);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Discovers a protectable item.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='fabricName'>
        /// Required. Fabric name.
        /// </param>
        /// <param name='protectionContainerName'>
        /// Required. Protection container name.
        /// </param>
        /// <param name='input'>
        /// Required. Discover Protectable Item Request.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// A standard service response for long running operations.
        /// </returns>
        public static Task<LongRunningOperationResponse> DiscoverProtectableItemAsync(this IProtectionContainerOperations operations, string fabricName, string protectionContainerName, DiscoverProtectableItemRequest input, CustomRequestHeaders customRequestHeaders)
        {
            return operations.DiscoverProtectableItemAsync(fabricName, protectionContainerName, input, customRequestHeaders, CancellationToken.None);
        }
        
        /// <summary>
        /// Get the protected container by Id.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='fabricName'>
        /// Required. Fabric Name.
        /// </param>
        /// <param name='protectionContainerName'>
        /// Required. Protection Container Name.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the Protection Container object.
        /// </returns>
        public static ProtectionContainerResponse Get(this IProtectionContainerOperations operations, string fabricName, string protectionContainerName, CustomRequestHeaders customRequestHeaders)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IProtectionContainerOperations)s).GetAsync(fabricName, protectionContainerName, customRequestHeaders);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Get the protected container by Id.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='fabricName'>
        /// Required. Fabric Name.
        /// </param>
        /// <param name='protectionContainerName'>
        /// Required. Protection Container Name.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the Protection Container object.
        /// </returns>
        public static Task<ProtectionContainerResponse> GetAsync(this IProtectionContainerOperations operations, string fabricName, string protectionContainerName, CustomRequestHeaders customRequestHeaders)
        {
            return operations.GetAsync(fabricName, protectionContainerName, customRequestHeaders, CancellationToken.None);
        }
        
        /// <summary>
        /// The Get Operation Status operation returns the status of the
        /// specified operation. After calling an asynchronous operation, you
        /// can call Get Operation Status to determine whether the operation
        /// has succeeded, failed, or is still in progress.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// Service response for operation which change status of protection
        /// container.
        /// </returns>
        public static DiscoverProtectableItemResponse GetDiscoverProtectableItemStatus(this IProtectionContainerOperations operations, string operationStatusLink)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IProtectionContainerOperations)s).GetDiscoverProtectableItemStatusAsync(operationStatusLink);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// The Get Operation Status operation returns the status of the
        /// specified operation. After calling an asynchronous operation, you
        /// can call Get Operation Status to determine whether the operation
        /// has succeeded, failed, or is still in progress.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='operationStatusLink'>
        /// Required. Location value returned by the Begin operation.
        /// </param>
        /// <returns>
        /// Service response for operation which change status of protection
        /// container.
        /// </returns>
        public static Task<DiscoverProtectableItemResponse> GetDiscoverProtectableItemStatusAsync(this IProtectionContainerOperations operations, string operationStatusLink)
        {
            return operations.GetDiscoverProtectableItemStatusAsync(operationStatusLink, CancellationToken.None);
        }
        
        /// <summary>
        /// Get the list of all ProtectionContainers for the given server.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='fabricName'>
        /// Required. Fabric Unique name.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the list ProtectionContainers operation.
        /// </returns>
        public static ProtectionContainerListResponse List(this IProtectionContainerOperations operations, string fabricName, CustomRequestHeaders customRequestHeaders)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IProtectionContainerOperations)s).ListAsync(fabricName, customRequestHeaders);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Get the list of all ProtectionContainers for the given server.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='fabricName'>
        /// Required. Fabric Unique name.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the list ProtectionContainers operation.
        /// </returns>
        public static Task<ProtectionContainerListResponse> ListAsync(this IProtectionContainerOperations operations, string fabricName, CustomRequestHeaders customRequestHeaders)
        {
            return operations.ListAsync(fabricName, customRequestHeaders, CancellationToken.None);
        }
        
        /// <summary>
        /// Get the list of all ProtectionContainers for the given vault.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the list ProtectionContainers operation.
        /// </returns>
        public static ProtectionContainerListResponse ListAll(this IProtectionContainerOperations operations, CustomRequestHeaders customRequestHeaders)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IProtectionContainerOperations)s).ListAllAsync(customRequestHeaders);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <summary>
        /// Get the list of all ProtectionContainers for the given vault.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.SiteRecovery.IProtectionContainerOperations.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <returns>
        /// The response model for the list ProtectionContainers operation.
        /// </returns>
        public static Task<ProtectionContainerListResponse> ListAllAsync(this IProtectionContainerOperations operations, CustomRequestHeaders customRequestHeaders)
        {
            return operations.ListAllAsync(customRequestHeaders, CancellationToken.None);
        }
    }
}
