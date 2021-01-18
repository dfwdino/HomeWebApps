using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;


namespace HomeApps.Infrastructure
{
    static public class Helper
    {
        static public void CopyClass<T>(T source, T destion)
        {

            System.Type destionclass = destion.GetType();
            foreach (PropertyInfo property in source.GetType().GetProperties())
            {
                PropertyInfo other = destionclass.GetProperty(property.Name);

                if (other != null)
                {
                    var test = property.GetValue(property.Name);
                    other.SetValue(destionclass, property.GetValue(source, null), null);
                }
            }

        }

        static public void DuckCopyShallow<T1, T2>(T1 dst, T2 src)
        {
            var srcT = src.GetType();
            var dstT = dst.GetType();
            foreach (var f in srcT.GetFields())
            {
                var dstF = dstT.GetField(f.Name);
                if (dstF == null)
                    continue;
                dstF.SetValue(dst, f.GetValue(src));
            }

            foreach (var f in srcT.GetProperties())
            {
                try
                {
                    var dstF = dstT.GetProperty(f.Name);
                    if (dstF == null)
                        continue;

                    dstF.SetValue(dst, f.GetValue(src, null), null);
                }
                ///Really need to write this error out.
                catch (Exception ex)
                {
                    var errormessage = ex.Message;
                }

            }

            //return dst;
        }

    }

}