using SportApp_Business.Common;
using SportApp_Infrastructure.Model.CategoryModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.CategoryCommnad
{
    public class CreateCategoryCommand : ICommand<bool>
    {
        public Guid SportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateCategoryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(CreateCategoryCommand request,CancellationToken cancellationToken)
            {
                var model = new CreateCategoryModel
                {
                    SportId = request.SportId,
                    Name = request.Name,
                    Description = request.Description,
                };
                return await _unitOfWork.Categorys.Create(model);
            }
        }
    }
}
