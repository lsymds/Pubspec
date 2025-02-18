using Shouldly;

namespace LSymds.Pubspec.Tests;

public class DependencyTests
{
    public class SimpleVersionTests
    {
        [Fact]
        public void DeserializesCorrectly()
        {
            // Arrange.
            var pubspec = @"
{
    ""name"": ""foo"",
    ""version"": ""1.0.0"",
    ""dependencies"": {
        ""foo"": ""1.0.0"",
        ""bar"": {
            ""version"": ""2.0.0"",
            ""hosted"": {
                ""url"": ""https://pub.dev""
            }
        }
    }
}
";
            
            // Act.
            var sut = Pubspec.FromJson(pubspec);
            
            // Assert.
            sut.Dependencies.ShouldNotBeNull();
            sut.Dependencies.ShouldContainKey("foo");
            sut.Dependencies["foo"].Version.ShouldBe("1.0.0");
        }
    }
}