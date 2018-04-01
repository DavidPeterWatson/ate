
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TaskPocoApp
{

    //
    public class User
    {

        //
        public string UserId { get; set; }
        //
        public string UserName { get; set; }
        //
        public string Password { get; set; }
        //
        public string Status { get; set; }
        //

    }

    //
    public class Task
    {

        //
        public string TaskId { get; set; }
        //
        public string UserUserId { get; set; }
        //
        public string Name { get; set; }
        //
        public DateTime DueDate { get; set; }
        //
        public string Status { get; set; }
        //
        public object User { get; set; }
        //

    }

    //
    public class TaskType
    {

        //
        public string Name { get; set; }
        //
        public string Description { get; set; }
        //
        public int Id { get; set; }
        //

    }

    //
}