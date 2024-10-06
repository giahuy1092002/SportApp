using MediatR;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Common
{
    public interface ICommandHandler<in TCommand,TResponse>:IRequestHandler<TCommand,TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}
