//using SportApp_Business.Common;
//using SportApp_Domain.Entities;
//using SportApp_Infrastructure.Model.PaymentModel;
//using SportApp_Infrastructure.Repositories.Interfaces;
//using SportApp_Infrastructure.Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SportApp_Business.Queries.Payment
//{
//    public class PaymentUrl : IQuery<string>
//    {
//        public class PaymentUrlHandler : IQueryHandler<PaymentUrl, string>
//        {
//            private readonly IVnPayService _vnPayService;
//            private readonly IUnitOfWork _unitOfWork;
//            public PaymentUrlHandler(IVnPayService vnPayService, IUnitOfWork unitOfWork)
//            {
//                _vnPayService = vnPayService;
//                _unitOfWork = unitOfWork;
//            }

//            public Task<string> Handle(PaymentUrl request, CancellationToken cancellationToken)
//            {
//                var model = new PaymentInformationModel
//                {
//                    BookingType = "Thanh toán online qua VNPay",
//                    BookingDescription = "Thanh toán đặt sân",
//                    Amount = request.Price,
//                    BookingId = booking.Id.ToString(),
//                    Name = "Thanh toán đặt sân"
//                };
//                var url = _vnPayService.CreatePaymentUrl(model, _httpContextAccessor.HttpContext);
//                return url;
//            }
//        }
//    }
//}
