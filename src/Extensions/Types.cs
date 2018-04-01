using System;
using System.Linq;
using System.Reflection;

namespace ate.Extensions
{
    public static class Types
    {
        public static bool IsInstanceOf(this object obj, Type type)
        {
            return obj != null && type != null && type.GetTypeInfo().IsAssignableFrom(obj.GetType().GetTypeInfo());
            //return obj != null && type != null && type.IsAssignableFrom(obj.GetType());
        }


        public static TargetType Map<TargetType, SourceType>(this TargetType target, SourceType source)
        {
            // get property list of the target object.
            typeof(TargetType).GetProperties().ToList().ForEach(propertyInfo =>
            {
                // check whether source object has the the property
                var sourcePropertyInfo = typeof(SourceType).GetProperty(propertyInfo.Name);
                if (sourcePropertyInfo != null && sourcePropertyInfo.DeclaringType == propertyInfo.DeclaringType)
                {
                    // if yes, copy the value to the matching property
                    var value = sourcePropertyInfo.GetValue(source, null);
                    propertyInfo.SetValue(target, value, null);
                }
            });

            return target;
        }

    }

}