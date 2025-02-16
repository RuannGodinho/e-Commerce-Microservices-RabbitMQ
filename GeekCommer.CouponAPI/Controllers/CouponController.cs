﻿using GeekCommer.CouponAPI.Repository;
using GeekCommerce.CouponAPI.Data.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekCommer.CouponAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpGet("{couponCode}")]
        public async Task<ActionResult<CouponVO>> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _couponRepository.GetCouponByCouponCode(couponCode);

            if (coupon == null)
                return NotFound();

            return Ok(coupon);
        }
    }
}
