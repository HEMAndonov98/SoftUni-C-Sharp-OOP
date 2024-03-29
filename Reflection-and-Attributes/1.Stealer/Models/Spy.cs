﻿using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer.Models.Contracts
{
    public class Spy : ISpy
    {
        private readonly IVisualizer visualizer;
        private Type type;
        private FieldInfo[] fields;

        public Spy()
        {
            this.visualizer = new SpyVisualizer();
        }


        public string StealFieldInfo(string className,params string[] fieldNames)
        {
            Type classType = Type.GetType(className);
            this.type = classType;
            FieldInfo[] fields = classType
                .GetFields
                (
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance
                );
            this.fields = fields.Where(f => fieldNames.Contains(f.Name))
                .ToArray();

            return this.ShowData();
        }


        private string ShowData()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.visualizer.VisualizeClass(this.type));

            foreach (var field in this.fields)
            {
                sb.AppendLine(this.visualizer.VisualizeFields(field, this.type));
            }

            return sb.ToString().Trim();
        }
    }
}

