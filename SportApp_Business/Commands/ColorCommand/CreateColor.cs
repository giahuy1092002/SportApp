using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.ColorCommand
{
    public class CreateColor : ICommand<bool>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public class CreateColorHandler: ICommandHandler<CreateColor,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateColorHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(CreateColor request, CancellationToken cancellationToken)
            {
                var model = new CreateColorModel
                {
                    Name = request.Name,
                    Value = request.Value
                };
                return await _unitOfWork.Colors.Create(model);
            }
        }
    }
}
