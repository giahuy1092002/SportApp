using AutoMapper;
using SportApp_Business.Common;
using SportApp_Infrastructure.Model.NotificationModel;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Business.Commands.NotificationCommand
{
    public class CreateNotificationCommand : ICommand<bool>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public Guid UserId { get; set; }
        public Guid? RelatedId { get; set; } //Event, SportFied, System
        public string RelatedType { get; set; }
        public class CreateNotificationHandler : ICommandHandler<CreateNotificationCommand,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public CreateNotificationHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<bool> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var notification = _mapper.Map<CreateNotificationModel>(request);
                    var result = await _unitOfWork.Notifications.Create(notification);
                    _unitOfWork.CommitTransaction();
                    return await Task.FromResult(true);
                }
                catch (Exception ex)
                {
                    _unitOfWork?.RollbackTransaction();
                    throw;
                } 
                
            }
        }
    }
}
