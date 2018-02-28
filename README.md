# ate

Application Templating Engine

Yet another templating engine. Why? I wanted:
- To template folders and files, not just individual files
- Use 'brackets' that created valid code

## Overview

The purpose of the ate is to be able to template/scaffold an application quickly and modify the templates easily.

## Project Breakdown

### Definitions

This is a base structure that serves as a go between for importing, exporting and templates. Basically just POCOs. Interface for importing and exporting.

### CLI

Command Line Interface application that calls the necessary libraries for importing application models, exporting application models and applying to templates. Dependency inversion of importers and exporters by examining folder.

### YAML

Yaml implementation of importing and exporting interfaces.

### SQL

SQL Database implementation of importing interface.

### Templating

Applies class to template folder/file.

### Projects

The projects library takes the settings in a project.yaml file and applies the application definition to a template.

## Getting Started

[Install ate](https://github.com/DavidPeterWatson/ate/tree/master/installation)

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

## Warning

The coding standards in this project are horrible. It needs serious refactoring. Suggestions and comments are welcome.
