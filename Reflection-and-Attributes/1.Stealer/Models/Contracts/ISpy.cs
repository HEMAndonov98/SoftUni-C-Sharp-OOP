﻿namespace Stealer.Models.Contracts
{
    public interface ISpy
    {
        string StealFieldInfo(string className,params string[] fieldNames);
    }
}