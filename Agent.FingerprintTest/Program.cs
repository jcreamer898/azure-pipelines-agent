using Agent.Plugins.PipelineCache;
using Agent.Sdk;
using System;

namespace Agent.FingerprintTest
{
    class Test
    {
        public Test() { }

        public void Run(string dir)
        {
            using (var hostContext = new TestHostContext(this))
            {
                var context = new AgentTaskPluginExecutionContext(hostContext.GetTrace());
                context.SetVariable("system.defaultworkingdirectory", @"D:\1JS\midgard");
                
                FingerprintCreator.EvaluateKeyToFingerprint(context, dir , new[] { "**/Podfile.lock" });
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();
            test.Run(@"D:\1JS\midgard");
        }
    }
}
