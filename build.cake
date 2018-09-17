///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx => {
   // Executed BEFORE the first task.
   Information("Running tasks...");
});

Teardown(ctx => {
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
   .Does(() => {
      var settings = new DotNetCoreCleanSettings {
         Configuration = configuration
      };

      DotNetCoreClean("./src/NoteWorx.FX", settings);
      DotNetCoreClean("./src/NoteWorx.Infrastructure.Data", settings);
      DotNetCoreClean("./src/NoteWorx.Web", settings);
   });

Task("Restore")
   .IsDependentOn("Clean")
   .Does(() => DotNetCoreRestore("./NoteWorx.sln"));

Task("Build")
   .IsDependentOn("Restore")
   .Does(() => {
      var settings = new DotNetCoreBuildSettings
      {
         Configuration = configuration
      };

      DotNetCoreBuild("./NoteWorx.sln", settings);
   });

Task("Default").IsDependentOn("Build");

RunTarget(target);
