using Sapphire.Data;
using Sapphire.Data.Yaml;

namespace Sapphire.DockerCompose.Schema.Tests;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class ComposeParse
{
    [SetUp]
    public void Setup()
    {
    }
    

    [Test]
    public void Test1()
    {
        var files = Directory.GetFiles("./Files");

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
        
        foreach (var file in files)
        {
            var text = File.ReadAllText(file);
            var stack = deserializer.Deserialize<YamlDockerStack>(text);
        }

        Assert.True(files.Any());
    }
}