using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

IConfig config;
#if DEBUG
config = new DebugBuildConfig();
#else
config = DefaultConfig.Instance;
#endif

BenchmarkRunner.Run(typeof(Program).Assembly, config);