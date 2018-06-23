using System;
using System.Collections.Generic;
using System.Text;

namespace TeduCoreApp.Data.Enums
{
    public enum PaymentMethod
    {
        //các phương thức thanh toán
        CashOnDelivery, //trả tiền lúc nhận hàng
        OnlinBanking,   //banking onl
        PaymentGateway, //
        Visa,
        MasterCard,
        PayPal,
        Atm
    }
}
