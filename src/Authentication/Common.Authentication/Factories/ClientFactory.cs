﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Hyak.Common;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication.Properties;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Microsoft.Azure.Common.Authentication.Factories
{
    public class ClientFactory : IClientFactory
    {
        private static readonly char[] uriPathSeparator = { '/' };

        private Dictionary<Type, IClientAction> actions;
        private List<DelegatingHandler> handlers;

        public ClientFactory()
        {
            actions = new Dictionary<Type, IClientAction>();
            UserAgents = new List<ProductInfoHeaderValue>();
            handlers = new List<DelegatingHandler>();
        }

        public virtual TClient CreateArmClient<TClient>(AzureContext context, AzureEnvironment.Endpoint endpoint) where TClient : Microsoft.Rest.ServiceClient<TClient>
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.NoSubscriptionInContext);
            }

            var creds = AzureSession.AuthenticationFactory.GetServiceClientCredentials(context);
            TClient client = CreateCustomArmClient<TClient>(context.Environment.GetEndpointAsUri(endpoint), creds, handlers.ToArray());

            var subscriptionId = typeof(TClient).GetProperty("SubscriptionId");
            if (subscriptionId != null && context.Subscription != null)
            {
                subscriptionId.SetValue(client, context.Subscription.Id.ToString());
            }

            return client;
        }

        public virtual TClient CreateCustomArmClient<TClient>(params object[] parameters) where TClient : Microsoft.Rest.ServiceClient<TClient>
        {
            List<Type> types = new List<Type>();
            foreach (object obj in parameters)
            {
                types.Add(obj.GetType());
            }
            
            var constructor = typeof(TClient).GetConstructor(types.ToArray());

            if (constructor == null)
            {
                throw new InvalidOperationException(string.Format(Resources.InvalidManagementClientType, typeof(TClient).Name));
            }

            TClient client = (TClient)constructor.Invoke(parameters);

            foreach (ProductInfoHeaderValue userAgent in UserAgents)
            {
                client.UserAgent.Add(userAgent);
            }

            return client;
        }

        public virtual TClient CreateClient<TClient>(AzureContext context, AzureEnvironment.Endpoint endpoint) where TClient : ServiceClient<TClient>
        {
            if (context == null)
            {
                var exceptionMessage = endpoint == AzureEnvironment.Endpoint.ServiceManagement
                    ? Resources.InvalidDefaultSubscription
                    : Resources.NoSubscriptionInContext;
                throw new ApplicationException(exceptionMessage);
            }

            SubscriptionCloudCredentials creds = AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context, endpoint);
            TClient client = CreateCustomClient<TClient>(creds, context.Environment.GetEndpointAsUri(endpoint), handlers.ToArray());

            return client;
        }

        public virtual TClient CreateClient<TClient>(AzureSMProfile profile, AzureEnvironment.Endpoint endpoint) where TClient : ServiceClient<TClient>
        {
            TClient client = CreateClient<TClient>(profile.Context, endpoint);

            foreach (IClientAction action in actions.Values)
            {
                action.Apply<TClient>(client, profile, endpoint);
            }

            return client;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TClient"></typeparam>
        /// <param name="subscription"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public virtual TClient CreateClient<TClient>(AzureSMProfile profile, AzureSubscription subscription, AzureEnvironment.Endpoint endpoint) where TClient : ServiceClient<TClient>
        {
            if (subscription == null)
            {
                throw new ApplicationException(Resources.InvalidDefaultSubscription);
            }

            if (!profile.Accounts.ContainsKey(subscription.Account))
            {
                throw new ArgumentException(string.Format("Account with name '{0}' does not exist.", subscription.Account), "accountName");
            }

            if (!profile.Environments.ContainsKey(subscription.Environment))
            {
                throw new ArgumentException(string.Format(Resources.EnvironmentNotFound, subscription.Environment));
            }

            AzureContext context = new AzureContext(subscription,
                profile.Accounts[subscription.Account],
                profile.Environments[subscription.Environment]);

            TClient client = CreateClient<TClient>(context, endpoint);

            foreach (IClientAction action in actions.Values)
            {
                action.Apply<TClient>(client, profile, endpoint);
            }

            return client;
        }

        public virtual TClient CreateCustomClient<TClient>(params object[] parameters) where TClient : ServiceClient<TClient>
        {
            List<Type> types = new List<Type>();
            foreach (object obj in parameters)
            {
                types.Add(obj.GetType());
            }

            var constructor = typeof(TClient).GetConstructor(types.ToArray());

            if (constructor == null)
            {
                throw new InvalidOperationException(string.Format(Resources.InvalidManagementClientType, typeof(TClient).Name));
            }

            TClient client = (TClient)constructor.Invoke(parameters);

            foreach (ProductInfoHeaderValue userAgent in UserAgents)
            {
                client.UserAgent.Add(userAgent);
            }

            return client;
        }

        public virtual HttpClient CreateHttpClient(string endpoint, ICredentials credentials)
        {
            return CreateHttpClient(endpoint, CreateHttpClientHandler(endpoint, credentials));
        }

        public virtual HttpClient CreateHttpClient(string endpoint, HttpMessageHandler effectiveHandler)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException("endpoint");
            }

            Uri serviceAddr = new Uri(endpoint);
            HttpClient client = new HttpClient(effectiveHandler)
            {
                BaseAddress = serviceAddr,
                MaxResponseContentBufferSize = 30 * 1024 * 1024
            };

            client.DefaultRequestHeaders.Accept.Clear();

            return client;
        }

        public static HttpClientHandler CreateHttpClientHandler(string endpoint, ICredentials credentials)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException("endpoint");
            }

            // Set up our own HttpClientHandler and configure it
            HttpClientHandler clientHandler = new HttpClientHandler();

            if (credentials != null)
            {
                // Set up credentials cache which will handle basic authentication
                CredentialCache credentialCache = new CredentialCache();

                // Get base address without terminating slash
                string credentialAddress = new Uri(endpoint).GetLeftPart(UriPartial.Authority).TrimEnd(uriPathSeparator);

                // Add credentials to cache and associate with handler
                NetworkCredential networkCredentials = credentials.GetCredential(new Uri(credentialAddress), "Basic");
                credentialCache.Add(new Uri(credentialAddress), "Basic", networkCredentials);
                clientHandler.Credentials = credentialCache;
                clientHandler.PreAuthenticate = true;
            }

            // Our handler is ready
            return clientHandler;
        }

        public void AddAction(IClientAction action)
        {
            action.ClientFactory = this;
            actions[action.GetType()] = action;
        }

        public void AddHandler(DelegatingHandler handler)
        {
            handlers.Add(handler);
        }

        public void RemoveAction(Type actionType)
        {
            if (actions.ContainsKey(actionType))
            {
                actions.Remove(actionType);
            }
        }

        public List<ProductInfoHeaderValue> UserAgents { get; set; }
    }
}
