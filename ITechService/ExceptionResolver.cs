using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace ITechService
{
    public class ExceptionResolver
    {
        public static string Resolve(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            if (ex is DbEntityValidationException)
            {
                DbEntityValidationException dev = (DbEntityValidationException ) ex;
                sb.AppendLine("DbEntityValidation:");
                foreach (var item in dev.EntityValidationErrors)
                {
                    foreach (var b in item.ValidationErrors)
                    {
                        sb.AppendLine(string.Format("'{0}'- {1}", b.PropertyName, b.ErrorMessage));
                    }
                }
                return sb.ToString();
            }

            Exception ex2 = ex;
            sb.AppendLine(ex2.Message);
            while (ex2.InnerException != null)
            {
                ex2 = ex2.InnerException;
                sb.AppendLine(ex2.Message);
            }
            return sb.ToString();
        }

    }
}