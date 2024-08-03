using Discount.GRPC.Data;
using Discount.GRPC.Models;
using Discount.GRPC.Protos;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.GRPC.Services
{
    public class DiscountService(DiscountContext dbcontext) : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            //TODO: Get discount form db
                var coupons = await dbcontext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            if (coupons is null)
                coupons = new Coupon { ProductName = "No discount" };
            try
            {
                var couponModel = coupons.Adapt<CouponModel>();
                return couponModel;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            return base.CreateDiscount(request, context);
        }

        public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            return base.UpdateDiscount(request, context);
        }

        public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            return base.DeleteDiscount(request, context);
        }
    }
}
