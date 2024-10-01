using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.DotNet.XHarness.iOS.Shared.Execution;
using Xharness.Jenkins.TestTasks;

namespace Xharness.Jenkins {
	class NUnitTestTasksEnumerable : IEnumerable<RunTestTask> {

		readonly Jenkins jenkins;
		readonly IMlaunchProcessManager processManager;

		public NUnitTestTasksEnumerable (Jenkins jenkins, IMlaunchProcessManager processManager)
		{
			this.jenkins = jenkins ?? throw new ArgumentNullException (nameof (jenkins));
			this.processManager = processManager ?? throw new ArgumentNullException (nameof (processManager));
		}

		public IEnumerator<RunTestTask> GetEnumerator ()
		{
			var msbuildTasksTestsProject = new TestProject (TestLabel.Msbuild, Path.GetFullPath (Path.Combine (HarnessConfiguration.RootDirectory, "msbuild", "Xamarin.MacDev.Tasks.Tests", "Xamarin.MacDev.Tasks.Tests.csproj"))) {
				IsDotNetProject = true,
			};
			var env = new Dictionary<string, string>
			{
				{ "SYSTEM_MONO", this.jenkins.Harness.SYSTEM_MONO },
			};
			var buildiOSMSBuild = new MSBuildTask (jenkins: jenkins, testProject: msbuildTasksTestsProject, processManager: processManager) {
				SpecifyPlatform = false,
				ProjectConfiguration = "Debug",
				Platform = TestPlatform.All,
				Ignored = !jenkins.TestSelection.IsEnabled (TestLabel.Msbuild),
				SupportsParallelExecution = false,
			};
			var nunitExecutioniOSMSBuild = new DotNetTestTask (jenkins, buildiOSMSBuild, processManager) {
				TestProject = msbuildTasksTestsProject,
				ProjectConfiguration = "Debug",
				Platform = TestPlatform.All,
				TestName = "MSBuild tests",
				Mode = "Tasks",
				Timeout = TimeSpan.FromMinutes (60),
				Ignored = !jenkins.TestSelection.IsEnabled (TestLabel.Msbuild),
				SupportsParallelExecution = false,
			};
			yield return nunitExecutioniOSMSBuild;

			var msbuildIntegrationTestsProject = new TestProject (TestLabel.Msbuild, Path.GetFullPath (Path.Combine (HarnessConfiguration.RootDirectory, "msbuild", "Xamarin.MacDev.Tests", "Xamarin.MacDev.Tests.csproj"))) {
				IsDotNetProject = true,
			};
			var buildiOSMSBuildIntegration = new MSBuildTask (jenkins: jenkins, testProject: msbuildIntegrationTestsProject, processManager: processManager) {
				SpecifyPlatform = false,
				ProjectConfiguration = "Debug",
				Platform = TestPlatform.All,
				Ignored = !jenkins.TestSelection.IsEnabled (TestLabel.Msbuild),
				SupportsParallelExecution = false,
			};
			var nunitExecutioniOSMSBuildIntegration = new DotNetTestTask (jenkins, buildiOSMSBuildIntegration, processManager) {
				TestProject = msbuildIntegrationTestsProject,
				ProjectConfiguration = "Debug",
				Platform = TestPlatform.All,
				TestName = "MSBuild tests",
				Mode = "Integration",
				Timeout = TimeSpan.FromMinutes (120),
				Ignored = !jenkins.TestSelection.IsEnabled (TestLabel.Msbuild),
				SupportsParallelExecution = false,
			};
			yield return nunitExecutioniOSMSBuildIntegration;

			var buildMTouch = new MakeTask (jenkins: jenkins, processManager: processManager) {
				TestProject = new TestProject (TestLabel.Mtouch, Path.GetFullPath (Path.Combine (HarnessConfiguration.RootDirectory, "mtouch", "mtouchtests.sln"))),
				SpecifyPlatform = false,
				SpecifyConfiguration = false,
				Platform = TestPlatform.iOS,
				Target = "dependencies",
				WorkingDirectory = Path.GetFullPath (Path.Combine (HarnessConfiguration.RootDirectory, "mtouch")),
			};
			var nunitExecutionMTouch = new NUnitExecuteTask (jenkins, buildMTouch, processManager) {
				TestLibrary = Path.Combine (HarnessConfiguration.RootDirectory, "mtouch", "bin", "Debug", "mtouchtests.dll"),
				TestProject = new TestProject (TestLabel.Mtouch, Path.GetFullPath (Path.Combine (HarnessConfiguration.RootDirectory, "mtouch", "mtouchtests.csproj"))),
				Platform = TestPlatform.iOS,
				TestName = "MTouch tests",
				Timeout = TimeSpan.FromMinutes (180),
				Ignored = !jenkins.TestSelection.IsEnabled (TestLabel.Mtouch) || !jenkins.TestSelection.IsEnabled (PlatformLabel.iOS),
				InProcess = true,
			};
			yield return nunitExecutionMTouch;

			var buildGenerator = new MakeTask (jenkins: jenkins, processManager: processManager) {
				TestProject = new TestProject (TestLabel.Generator, Path.GetFullPath (Path.Combine (HarnessConfiguration.RootDirectory, "..", "src", "generator.sln"))),
				SpecifyPlatform = false,
				SpecifyConfiguration = false,
				Platform = TestPlatform.iOS,
				Target = "build-unit-tests",
				WorkingDirectory = Path.GetFullPath (Path.Combine (HarnessConfiguration.RootDirectory, "generator")),
			};
			var runGenerator = new NUnitExecuteTask (jenkins, buildGenerator, processManager) {
				TestLibrary = Path.Combine (HarnessConfiguration.RootDirectory, "generator", "bin", "Debug", "generator-tests.dll"),
				TestProject = new TestProject (TestLabel.Generator, Path.GetFullPath (Path.Combine (HarnessConfiguration.RootDirectory, "generator", "generator-tests.csproj"))),
				Platform = TestPlatform.iOS,
				TestName = "Generator tests",
				Mode = "NUnit",
				Timeout = TimeSpan.FromMinutes (10),
				Ignored = !jenkins.TestSelection.IsEnabled (TestLabel.Generator) || !jenkins.Harness.INCLUDE_XAMARIN_LEGACY,
			};
			yield return runGenerator;

			var buildCecilTestsProject = new TestProject (TestLabel.Cecil, Path.GetFullPath (Path.Combine (HarnessConfiguration.RootDirectory, "cecil-tests", "cecil-tests.csproj"))) {
				IsDotNetProject = true,
			};
			var buildCecilTests = new MSBuildTask (jenkins: jenkins, testProject: buildCecilTestsProject, processManager: processManager) {
				TestProject = buildCecilTestsProject,
				SpecifyPlatform = false,
				SpecifyConfiguration = false,
				Platform = TestPlatform.iOS,
				Ignored = !jenkins.TestSelection.IsEnabled (TestLabel.Cecil),
			};
			var runCecilTests = new DotNetTestTask (jenkins, buildCecilTests, processManager) {
				TestProject = buildCecilTestsProject,
				Platform = TestPlatform.iOS,
				TestName = "Cecil-based tests",
				Timeout = TimeSpan.FromMinutes (10),
				Ignored = !jenkins.TestSelection.IsEnabled (TestLabel.Cecil) || !jenkins.TestSelection.IsEnabled (PlatformLabel.Dotnet),
			};
			yield return runCecilTests;

			var buildSampleTestsProject = new TestProject (TestLabel.SampleTester, Path.GetFullPath (Path.Combine (HarnessConfiguration.RootDirectory, "sampletester", "sampletester.csproj")));
			var buildSampleTests = new MSBuildTask (jenkins: jenkins, testProject: buildSampleTestsProject, processManager: processManager) {
				SpecifyPlatform = false,
				Platform = TestPlatform.All,
				ProjectConfiguration = "Debug",
			};
			var runSampleTests = new NUnitExecuteTask (jenkins, buildSampleTests, processManager) {
				TestLibrary = Path.Combine (HarnessConfiguration.RootDirectory, "sampletester", "bin", "Debug", "sampletester.dll"),
				TestProject = new TestProject (TestLabel.SampleTester, Path.GetFullPath (Path.Combine (HarnessConfiguration.RootDirectory, "sampletester", "sampletester.csproj"))),
				Platform = TestPlatform.All,
				TestName = "Sample tests",
				Timeout = TimeSpan.FromDays (1), // These can take quite a while to execute.
				InProcess = true,
				Ignored = true, // Ignored by default, can be run manually. On CI will execute if the label 'run-sample-tests' is present on a PR (but in Azure Devops on a different bot).
			};
			yield return runSampleTests;
		}

		IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();
	}
}
