# ATE - Application Templating Engine

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

### Templator

Applies application mapping to template folder/file.