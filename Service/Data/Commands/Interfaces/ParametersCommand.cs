using Data.Core.Interfaces;
using Domain.Sql;

namespace Data.Commands
{
    public abstract class ParametersCommand<ResultType, RequestType> : Command<ResultType>
        where ResultType : IResult
        where RequestType : IRequest
    {
        public ParametersCommand(IDapperClient dapperClientParam)
            : base(dapperClientParam)
        {}
    }
}
