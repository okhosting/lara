﻿/*
Copyright (c) 2019 Integrative Software LLC
Created: 5/2019
Author: Pablo Carbonell
*/

using Integrative.Clara.Main;
using Xunit;

namespace Integrative.Clara.Tests.Main
{
    public class PublishedTesting
    {
        [Fact]
        public void UnpublishRemoves()
        {
            using (var published = ClaraUI.GetPublished())
            {
                published.Publish("/", new StaticContent(new byte[0]));
                published.Publish("/lala", new StaticContent(new byte[0]));
                ClaraUI.UnPublish("/");
                Assert.True(published.TryGetNode("/lala", out _));
                Assert.False(published.TryGetNode("/", out _));
            }
        }
    }
}