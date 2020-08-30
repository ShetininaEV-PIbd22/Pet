using PetClinicBusinessLogic.BusinessLogics;
using PetClinicBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Reflection;
using PetClinicDatabaseImplement.Models;
using PetClinicBusinessLogic.ViewModels;

namespace PetClinicDatabaseImplement.Implements
{
    public class BackupLogic : BackUpAbstractLogic
    {
        protected override Assembly GetAssembly()
        {
            return typeof(BackupLogic).Assembly;
        }
        protected override List<PropertyInfo> GetFullList()
        {
            using (var context = new PetClinicDatabase())
            {
                Type type = context.GetType();
                return type.GetProperties().Where(x => x.PropertyType.FullName.StartsWith("Microsoft.EntityFrameworkCore.DbSet")).ToList();
            }
        }
        protected override List<T> GetList<T>()
        {
            using (var context = new PetClinicDatabase())
            {
                return context.Set<T>().ToList();
            }
        }
    }
}

