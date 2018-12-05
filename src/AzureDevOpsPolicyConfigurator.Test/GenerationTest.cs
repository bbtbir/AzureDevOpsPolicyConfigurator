﻿using System.IO;
using AzureDevOpsPolicyConfigurator.Logic;
using Xunit;

namespace AzureDevOpsPolicyConfigurator.Test
{
    /// <summary>
    /// Generation test.
    /// </summary>
    public class GenerationTest
    {
#pragma warning disable xUnit1004 // Test methods should not be skipped
        [Fact(DisplayName = "Generating structure and checking", Skip = "Can only be executed locally!")]
#pragma warning restore xUnit1004 // Test methods should not be skipped
        private void GenerateStructureAndTestFileExistence()
        {
            new StructureGenerator(new JsonFileWriter(), new ConnectionProvider()).Execute(new GeneratorSettings()
            {
                CollectionUrl = "https://tfs.bbtlocal.ch/BBT",
                Auth = AuthMethod.Ntlm,
                Destination = "Project"
            });

            Assert.True(Directory.Exists("Project"));
            Assert.True(File.Exists("Project\\projects.json"));

            Assert.True(Directory.Exists("Project\\Framework"));
            Assert.True(File.Exists("Project\\Framework\\types.json"));

            Assert.True(Directory.Exists("Project\\Framework\\doc.framework"));
            Assert.True(File.Exists("Project\\Framework\\doc.framework\\policies.json"));
        }
    }
}
