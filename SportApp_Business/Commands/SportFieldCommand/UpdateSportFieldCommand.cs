using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.SportFieldCommand
{
    public class UpdateSportFieldCommand : ICommand<bool>
    {
        public Guid SportFieldId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Sport {  get; set; }

        public class UpdateSportFieldHandler : ICommandHandler<UpdateSportFieldCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateSportFieldHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(UpdateSportFieldCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    return await Task.FromResult(true);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }
    }
}
