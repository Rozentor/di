﻿using Autofac;
using FluentAssertions;
using NUnit.Framework;
using TagCloud.Utility.Container;
using TagCloud.Utility.Models.Tag;
using TagCloud.Utility.Models.Tag.Container;

namespace TagCloud.Tests.ForTagUtility
{
    [TestFixture]
    public class TagReader_Should 
    {
        private readonly IContainer container = ContainerConfig.StandartContainer;

        [Test]
        public void ReadTags()
        {
            var tagContainer = container.Resolve<TagContainer>();
            var reader = container.Resolve<TagReader>();
            var expectBigSize = tagContainer.GetTagGroupFor(10 / 17d).FontSize;
            var expectSizeOfAverage = tagContainer.GetTagGroupFor(6 / 17d).FontSize;
            var expectSizOfSmall = tagContainer.GetTagGroupFor(1 / 17d).FontSize;

            var tags = reader.ReadTags(new[]
            {
                "Big", "Big", "Big", "Big", "Big", "Big", "Big", "Big", "Big", "Big",
                "Average", "Average", "Average", "Average", "Average", "Average",
                "Small"
            });

            tags.Should().HaveCount(3)
                .And.Contain(item =>
                    item.Word == "Big" && item.FontSize == expectBigSize)
                .And.Contain(item =>
                    item.Word == "Average" && item.FontSize == expectSizeOfAverage)
                .And.Contain(item =>
                    item.Word == "Small" && item.FontSize == expectSizOfSmall);
        }
    }
}