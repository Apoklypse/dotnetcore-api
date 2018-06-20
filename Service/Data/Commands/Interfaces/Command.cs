using Data.Core.Interfaces;
using Domain.Sql;
using System;
using System.Collections.Generic;

namespace Data.Commands
{
    public abstract class Command<ResultType>
        where ResultType : IResult
    {
        protected string procedureName;
        protected readonly IDapperClient dapperClient;

        public Command(IDapperClient dapperClientParam)
        {
            this.dapperClient = dapperClientParam ?? throw new ArgumentNullException(nameof(dapperClientParam));
        }

        public abstract IEnumerable<ResultType> Execute();
    }
}
