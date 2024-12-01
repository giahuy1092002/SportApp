using SportApp_Business.Common;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.CategoryCommnad
{
    public class DeleteCategoryCommand : ICommand<bool>
    {
        public Guid CategoryId { get; set; }
        public class DeleteCategoryHandler : ICommandHandler<DeleteCategoryCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteCategoryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Categorys.Delete(request.CategoryId);
            }
        }
    }
}
