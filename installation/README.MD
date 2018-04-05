# ate installation

1. Install .NET Core Runtime. Note: Not ASP.net Core.

[Mac](https://www.microsoft.com/net/download/macos/run)

[Windows](https://www.microsoft.com/net/download/windows/run)

[Linux](https://www.microsoft.com/net/download/linux/run)

2. Copy files from the appropriate zip package in [this folder](https://github.com/DavidPeterWatson/ate/tree/master/installation) to an applicable folder on your machine. (eg: C:\Program Files\ate or /Library/ate)

Then add that folder to your Path environment variable.

you should be able to run `ate -h` from the command line. It should look like the following:

```terminal
ate version 1.0.53.0

parameters:

-h this help info
-v version
-l list available import and export types
-i import
-e export
-p render project
-r replace text in folder and file names (for template building)
-s search text
-n new text

usage:

ate -i ImportType ImportParameters -e ExportType Export Parameters
ate -p Project.yaml
ate -r Directory -s SearchText -n NewText

```
