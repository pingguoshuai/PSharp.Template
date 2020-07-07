using System;
using System.Collections.Generic;
using System.Text;
using Util.Files.Paths;
using Util.Helpers;
using Util.Randoms;

namespace PSharp.Template.Core.Files.Paths
{
    public class PSharpPathGenerator : PathGeneratorBase
    {
        public IBasePath BasePath { get; }

        public PSharpPathGenerator(IBasePath basePath, IRandomGenerator randomGenerator) : base(randomGenerator)
        {
            BasePath = basePath;
        }

        protected override string GeneratePath(string fileName)
        {
            return $"{BasePath.GetPath()}/{Time.GetDateTime():yyyyMMdd}/{fileName}";
        }
    }
}
