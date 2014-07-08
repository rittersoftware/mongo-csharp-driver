﻿/* Copyright 2013-2014 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Connections;

namespace MongoDB.Driver.Core.Servers
{
    /// <summary>
    /// Represents a MongoDB server.
    /// </summary>
    public interface IServer
    {
        // properties
        DnsEndPoint EndPoint { get; }
        ServerDescription Description { get; }

        // methods
        Task<IConnection> GetConnectionAsync(TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken));
        Task<ServerDescription> GetDescriptionAsync(int minimumRevision, TimeSpan timeout = default(TimeSpan), CancellationToken cancellationToken = default(CancellationToken));
    }

    /// <summary>
    /// Represents a server that hasn't been wrapped.
    /// </summary>
    public interface IRootServer : IServer, IDisposable
    {
    }
}
