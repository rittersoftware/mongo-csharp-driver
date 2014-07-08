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
using MongoDB.Driver.Core.Clusters;
using FluentAssertions;
using NUnit.Framework;

namespace MongoDB.Driver.Core.Tests.Clusters
{
    [TestFixture]
    public class TagTests
    {
        [Test]
        public void Constructor_should_initialize_all_fields()
        {
            var tag = new Tag("name", "value");
            tag.Name.Should().Be("name");
            tag.Value.Should().Be("value");
        }

        [Test]
        public void Constructor_should_throw_if_name_is_null()
        {
            Action action = () => new Tag(null, "value");
            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Constructor_should_throw_if_value_is_null()
        {
            Action action = () => new Tag("name", null);
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestCase("name", "?")]
        [TestCase("?", "value")]
        public void Equals_should_return_false_if_any_field_is_not_equal(string name, string value)
        {
            var tag1 = new Tag("name", "value");
            var tag2 = new Tag(name, value);
            tag1.Equals(tag2).Should().BeFalse();
            tag1.Equals((object)tag2).Should().BeFalse();
        }

        [Test]
        public void Equals_should_return_true_if_all_fields_are_equal()
        {
            var tag1 = new Tag("name", "value");
            var tag2 = new Tag("name", "value");
            tag1.Equals(tag2).Should().BeTrue();
            tag1.Equals((object)tag2).Should().BeTrue();
        }

        [Test]
        public void GetHashCode_should_be_equal_if_all_fields_are_equal()
        {
            var tag1 = new Tag("name", "value");
            var tag2 = new Tag("name", "value");
            tag1.GetHashCode().Should().Be(tag2.GetHashCode());
        }

        [TestCase("name", "?")]
        [TestCase("?", "value")]
        public void GetHashCode_should_not_be_equal_if_any_field_is_not_equal(string name, string value)
        {
            // note: theoretically hashcodes could collide but it's not likely (and they don't with these values)
            var tag1 = new Tag("name", "value");
            var tag2 = new Tag(name, value);
            tag1.GetHashCode().Should().NotBe(tag2.GetHashCode());
        }

        [Test]
        public void Name_should_return_the_correct_value()
        {
            var tag = new Tag("name", "value");
            tag.Name.Should().Be("name");
        }

        [Test]
        public void Value_should_return_the_correct_value()
        {
            var tag = new Tag("name", "value");
            tag.Value.Should().Be("value");
        }
    }
}
