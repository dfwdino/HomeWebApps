using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;


namespace HomeApps.Infrastructure
{
    static public class Helper
    {
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

        static public string GetUsersSchemasName(User user, IEnumerable<Schema> schemas)
        {

            var userschemaslist = user.UserSchemas.Where(mm => mm.Deleted == false).Select(a => a.SchemaID).ToList();

            var userschemas = schemas.Where(m => m.UserSchemas
                                            .Any(a => userschemaslist.Contains(m.SchemaID))).Select(m => m.SchemaName).ToList();

            return String.Join(",", userschemas);
        }

    }

}