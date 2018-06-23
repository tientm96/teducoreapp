using System;
using System.Collections.Generic;
using System.Text;

namespace TeduCoreApp.Data.Enums
{
    //Thay vì dùng kiểu int khai báo  cho từng cái thì dùng kiểu tập hợp Enum từ 0 đến n auto.
    public enum BillStatus
    {
        //các trạng thái của bill
        New, //0            //Mới 
        InProgress,         //đang tính
        Returned,           //trả lại
        Cancelled,          //hủy
        Completed //4       //hoàn thành
    }
}
