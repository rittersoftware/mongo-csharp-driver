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
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver.Core.Misc;

namespace MongoDB.Driver.Core.Connections
{
    public class BuildInfoResult
    {
        // fields
        private readonly BsonDocument _wrapped;

        // constructors
        public BuildInfoResult(BsonDocument wrapped)
        {
            _wrapped = Ensure.IsNotNull(wrapped, "wrapped");
        }

        // properties
        public int Bits
        {
            get
            {
                return _wrapped.GetValue("bits").ToInt32();
            }
        }

        public string GitCommitId
        {
            get
            {
                return _wrapped.GetValue("gitVersion").ToString();
            }
        }

        public SemanticVersion ServerVersion
        {
            get
            {
                return SemanticVersion.Parse(_wrapped.GetValue("version").ToString());
            }
        }

        public BsonDocument Wrapped
        {
            get
            {
                return _wrapped;
            }
        }
    }
}
