using SportApp_Business.Common;
using SportApp_Infrastructure.Model.CategoryModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportApp_Business.Commands.CategoryCommnad
{
    public class UpdateCategoryCommand : ICommand<bool>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public class UpdateCategoryHandler : ICommandHandler<UpdateCategoryCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateCategoryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var model = new UpdateCategoryModel
                {
                    CategoryId = request.CategoryId,
                    Name = request.Name,
                    Description = request.Description,
                };
                return await _unitOfWork.Categorys.Update(model);
            }
        }
    }
}
