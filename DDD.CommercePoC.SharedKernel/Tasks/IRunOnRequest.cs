﻿namespace DDD.CommercePoC.SharedKernel.Tasks
{
    public interface IRunOnRequest
    {
        void Execute();

        int Order { get; }
    }
}