using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using PSharp.Template.Core.Dependency;
using Util;
using Util.Reflections;

namespace PSharp.Template.Core.Caches
{
    public class CacheKeyManager : IISingletonDependency
    {
        public readonly List<Item> CacheList = new List<Item>();

        public CacheKeyManager()
        {
            Init();
        }

        private void Init()
        {
            IFind finder = new Finder();
            var assemblies = finder.GetAssemblies();
            Type[] packTypes = finder.Find(typeof(ICacheKey), assemblies).ToArray();
            foreach (var packType in packTypes)
            {
                var fields = packType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

                foreach (var fieldInfo in fields)
                {
                    string text = fieldInfo.Name;
                    var descAttr = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
                    if (descAttr != null)
                    {
                        text = descAttr.Description;
                    }

                    //CacheList.Add(new Item(text, fieldInfo.GetRawConstantValue().ToString()));
                    CacheList.Add(new Item(text, fieldInfo.GetValue(null).ToString()));
                }
            }
        }
    }
}
