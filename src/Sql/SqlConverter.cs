using System;
using System.Linq;
using System.Collections.Generic;

using ate.Conversion;
using System.IO;


using System.Data;
using System.Data.SqlClient;
using DatabaseSchemaReader.Procedures;
using DatabaseSchemaReader;

using ate.Definitions;

namespace ate.Sql
{
    public class SqlConverter : IConverter
    {
        public string Name => "sql";

        public List<string> Extensions => new List<string> { "sql" };

        public ExportResults<T> Export<T>(T Object, string[] parameters)
        {
            throw new NotImplementedException();
        }

        public ImportResults<T> Import<T>(string[] parameters)
        {

            string databaseType = parameters[0];
            string connectionString = parameters[1];

            System.Data.Common.DbConnection connection;

            switch (databaseType)
            {
                case "sqlserver":
                    connection = new SqlConnection(connectionString);//@"Data Source=.\SQLEXPRESS;Integrated Security=true;Initial Catalog=Northwind");
                    break;

                case "mysql":
                    connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);//(@"Server=localhost;Uid=root;Pwd=Password12!;Database=sakila;Allow User Variables=True;");
                    break;

                default:
                    throw new Exception("Database Type " + databaseType + " not recognised");
            }

            var app = new App();
            app.Modules = new List<Module>();


            var allEntities = new List<Entity>();

            try
            {
                connection.Open();
                app.Name = connection.Database;



                var databaseReader = new DatabaseSchemaReader.DatabaseReader(connection);
                //Then load the schema (this will take a little time on moderate to large database structures)
                var schema = databaseReader.ReadAll();

                foreach (var table in schema.Tables)
                {
                    var module = app.Modules.FirstOrDefault(findModule => findModule.Name == table.SchemaOwner);
                    if (module == null)
                    {
                        module = new Module();
                        module.Name = table.SchemaOwner;
                        module.Entities = new List<Entity>();
                        app.Modules.Add(module);
                    }

                    var entity = new Entity();
                    entity.PropertyGroups = new List<PropertyGroup>();

                    module.Entities.Add(entity);
                    allEntities.Add(entity);
                    entity.Name = table.Name;
                    var propertyGroup = new PropertyGroup();
                    propertyGroup.Properties = new List<Property>();

                    entity.PropertyGroups.Add(propertyGroup);
                    propertyGroup.Name = "Details";

                    var keyPropertyGroup = new PropertyGroup();
                    entity.PropertyGroups.Add(keyPropertyGroup);
                    keyPropertyGroup.Name = "Keys";

                    foreach (var column in table.Columns)
                    {
                        var property = new Property();
                        property.Name = column.Name;
                        if (column.Length.HasValue)
                        {
                            property.MaxLength = column.Length.Value;
                        }

                        switch (column.DataType.NetDataType)
                        {
                            case "System.Byte":
                                property.DataType = DataType.Integer;
                                property.DataTypeFormat = DataTypeFormat.Byte;
                                break;

                            case "System.Boolean":
                                property.DataType = DataType.Boolean;
                                break;

                            case "System.Int32":
                                property.DataType = DataType.Integer;
                                property.DataTypeFormat = DataTypeFormat.Integer;
                                break;

                            case "System.Long":
                                property.DataType = DataType.Integer;
                                property.DataTypeFormat = DataTypeFormat.LongInteger;
                                break;

                            case "System.DateTime":
                                property.DataType = DataType.DateTime;
                                break;

                            case "System.DateTimeOffset":
                                property.DataType = DataType.TimeSpan;
                                break;

                            case "System.Decimal":
                            case "System.Numeric":
                                property.DataType = DataType.Number;
                                break;

                            case "System.Guid":
                                property.DataType = DataType.Guid;
                                break;

                            case "System.String":
                                property.DataType = DataType.String;
                                break;

                            default:
                                property.DataType = DataType.String;
                                break;
                        }

                        if (column.IsPrimaryKey || column.IsForeignKey)
                        {
                            keyPropertyGroup.Properties.Add(property);
                        }
                        else
                        {
                            propertyGroup.Properties.Add(property);
                        }
                    }
                }

                foreach (var table in schema.Tables)
                {

                    var childEntity = allEntities.FirstOrDefault(findEntity => findEntity.Name == table.Name);

                    var propertyGroup = childEntity.PropertyGroups.FirstOrDefault(findPropertyGroup => findPropertyGroup.Name == "Details");

                    foreach (var foreignKey in table.ForeignKeys)
                    {
                        //var parentEntity = AllEntities.FirstOrDefault(findEntity => findEntity.Name == foreignKey.TableName);
                        var parentProperty = new Property();
                        propertyGroup.Properties.Add(parentProperty);

                        parentProperty.Name = foreignKey.Name;
                        parentProperty.DataType = DataType.Parent;
                        parentProperty.ParentName = foreignKey.RefersToSchema + "." + foreignKey.RefersToTable;
                        parentProperty.ForeignKeyName = foreignKey.Columns.First();

                    }
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                connection.Close();
            }

            var importResults = new ImportResults<T>();

            T t;
            t = (T)Convert.ChangeType(app, typeof(T));

            importResults.Result = t;
            importResults.FilePath = "";

            return importResults;

        }
    }
}