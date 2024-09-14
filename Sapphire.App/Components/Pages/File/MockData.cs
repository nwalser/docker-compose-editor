using Sapphire.Data;
using Sapphire.Data.Internal;
using Sapphire.Data.Yaml;

namespace Sapphire.App.Components.Pages.File;

public static class MockData
{
    public static DockerStack Stack => new()
    {
        Name = "Stack 1",
        Services =
        [
            new Service
            {
                Id = "mongo_db",
                ContainerName = "mongo_db",
                Image = "github_container_registry.com/nathaniel-walser/mongodb:14.9.1",
            },
            new Service
            {
                Id = "minio",
                ContainerName = "minio",
                Image = "github_container_registry.com/nathaniel-walser/minio:14.9.1",
            }
        ]
    };
}