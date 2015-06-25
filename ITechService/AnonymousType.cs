using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITechService
{
    public static class FromAnonymous
    {

        public static T From<T>(this T newObj, object fromObj)
        {
            //create instance of T type object:
            var newobject = newObj;

            //loop through the properties of the object you want to covert:          
            foreach (PropertyInfo pi in fromObj.GetType().GetProperties())
            {
                try
                {

                    //get the value of property and try 
                    //to assign it to the property of T type object:
                    if (newobject.GetType().GetProperty(pi.Name) != null)
                        if (pi.GetValue(fromObj, null) != null)
                            newobject.GetType().GetProperty(pi.Name).SetValue(newobject, pi.GetValue(fromObj, null), null);
                }
                catch { }
            }

            //return the T type object:         
            return newobject;
        }

        public static T CopyTo<T>(this object obj, T NewObj)
        {

            //create instance of T type object:
            var newobject = NewObj;

            //loop through the properties of the object you want to covert:          
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                try
                {

                    //get the value of property and try 
                    //to assign it to the property of T type object:
                    if (newobject.GetType().GetProperty(pi.Name)!=null)
                        if (pi.GetValue(obj, null)!=null)
                            newobject.GetType().GetProperty(pi.Name).SetValue(newobject, pi.GetValue(obj, null), null);
                }
                catch { }
            }

            //return the T type object:         
            return newobject;
        }


        /// <summary>
        /// use ToType(typeof(YourClass))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ToType<T>(this object obj, T type)
        {

            //create instance of T type object:
            //var newobject = Activator.CreateInstance(Type.GetType(type.ToString()));
            var newobject = Activator.CreateInstance(typeof(T)); 

            //loop through the properties of the object you want to covert:          
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
              try 
              {   

                //get the value of property and try 
                //to assign it to the property of T type object:
                  if (newobject.GetType().GetProperty(pi.Name) != null)
                      if (pi.GetValue(obj, null) != null)
                          newobject.GetType().GetProperty(pi.Name).SetValue(newobject, pi.GetValue(obj, null), null);
                // old ver tmp.GetType().GetProperty(pi.Name).SetValue(tmp, pi.GetValue(obj, null), null);
              }
              catch { }
             }  

           //return the T type object:         
            return newobject; 
        }

        public static object ToNonAnonymousList<T>(this List<T> list, Type t)
        {

            //define system Type representing List of objects of T type:
            var genericType = typeof(List<>).MakeGenericType(t);

            //create an object instance of defined type:
            var l = Activator.CreateInstance(genericType);

            //get method Add from from the list:
            MethodInfo addMethod = l.GetType().GetMethod("Add");

            //loop through the calling list:
            foreach (T item in list)
            {

                //convert each object of the list into T object 
                //by calling extension ToType<T>()
                //Add this object to newly created list:
                addMethod.Invoke(l, new object[] { item.ToType(t) });
            }

            //return List of T objects:
            return l;
        }
    }
}
