using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTimeDemo.Utility
{
    public class SD
    {
        public const string Role_Customer = "Customer";
        public const string Role_Employee = "Employee";
        public const string Role_Manager = "Manager";
        public const string Role_Admin = "Admin";
        //等待店家确认订单 -> 确认后改为准备中 -> 准备完成更改为订单完成、可取餐 -> 取餐后显示为订单完成
        //等待店家确认订单
        public const string StatusPending = "Pending";
        //public const string StatusApproved = "Approved";
        //店家确认后改为订单准备中
        public const string StatusInProcess = "Processing";
        //店家或顾客取消订单
        public const string StatusCancelled = "Cancelled";
        //店家准备完成,顾客可取餐
        public const string StatusReady = "Ready";
        //顾客取餐及付款后,店家结束订单
        public const string StatusCompleted = "Completed";
    }
}
