# Cli

Command line Interface for ate to:
- import app model to a file
- export app model to a file
- apply app model to a template


ate -i source-type [source type parameters] destination-type [destination parameters]

-i --import
-e --export
-t --template

ate -i sql 'sql string' -e yaml 'filename'

ate -i xml 'filename' -e yaml 'filename'

ate -t 'project file name'