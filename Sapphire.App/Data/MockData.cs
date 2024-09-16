﻿using Sapphire.Data.Internal;

namespace Sapphire.App.Data;

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
                Command = "run minio -c -p 9001",
                Environment = [
                    "port=9001",
                    "item=1000"
                ]
            },
            new Service
            {
                Id = "mongo_db",
                ContainerName = "keras",
                Image = "github_container_registry.com/nathaniel-walser/keras:14.9.1",
            },
        ]
    };
}