# ate installation

1. Install .NET Core Runtime. Note: Not ASP.net Core. 

https://www.microsoft.com/net/download/macos/run

https://www.microsoft.com/net/download/windows/run

https://www.microsoft.com/net/download/linux/run


2. Copy files from the appropriate zip package in [this folder](https://github.com/DavidPeterWatson/ate/tree/master/installation) to an applicable folder on your machine.

eg: C:\Program Files\ate

Then add that folder to your Path environment variable.

you should be able to run `ate` from the command line. It should look like the following:

```
ate version 1.0.47.0

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

C:\Users\WatsonDa>
```
