using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiaoHangTietKiem
{

    [Serializable]
    class Product {
        public string name { set; get; }
        public decimal weight { set; get; }
        public int quantity { set; get; }
        public int price { set; get; }
    }

    [Serializable]
    class Order
    {
        public string id { set; get; }
        public string pick_name { set; get; }
        public string pick_address { set; get; }
        public string pick_province { set; get; }
        public string pick_district { set; get; }
        public string pick_ward { set; get; }
        public string pick_tel { set; get; }
        public string tel { set; get; }
        public string name { set; get; }
        public string address { set; get; }
        public string province { set; get; }
        public string district { set; get; }
        public string ward { set; get; }
        public string hamlet { set; get; }
        public string is_freeship { set; get; }
        public string pick_date { set; get; }
        public decimal pick_money { set; get; }
        public string note { set; get; }
        public decimal value { set; get; }
        public string transport { set; get; }
        //Road - fly
        public string label_id { set; get; }
        public string partner_id { set; get; }
        public string status { set; get; }
        public string status_text { set; get; }
        public string created { set; get; }
        public string modified { set; get; }
        public string message { set; get; }
        public string deliver_date { set; get; }
        public string customer_fullname { set; get; }
        public string customer_tel { set; get; }
        public string storage_day { set; get; }
        public string ship_money { set; get; }
        public string insurance { set; get; }
        public decimal weight { set; get; }
    }

    //
    class OrderAddReqquest
    {
        public List<Product> products { set; get; }
        public Order order { set; get; }
    }

    class RespronseGhtk
    {
        public string success { set; get; }
        public string message { set; get; }
        public OrderResponse order { set; get; }
        public ErrorResponse error { set; get; }
        public Fee fee { set; get; }
        public List<Data> data { set; get; }
    }

    class OrderResponse
    {
        public string partner_id { set; get; }
        public string label { set; get; }
        public string area { set; get; }
        public string fee { set; get; }
        public string insurance_fee { set; get; }
        public string estimated_pick_time { set; get; }
        public string estimated_deliver_time { set; get; }
        public List<Product> products { set; get; }
        public decimal status_id { set; get; }
    }

    class ErrorResponse
    {
        public string code { set; get; }
        public string partner_id { set; get; }
        public string ghtk_label { set; get; }
        public string created { set; get; }
        public decimal status { set; get; }
    }

    class CalFeeRequest
    {
        public string pick_province { set; get; }
        public string pick_district { set; get; }
        public string province { set; get; }
        public string district { set; get; }
        public string address { set; get; }
        public decimal weight { set; get; }
        public decimal value { set; get; }
        public string transport { set; get; }
    }

    class Fee
    {
        public string name { set; get; }
        public decimal fee { set; get; }
        public decimal insurance_fee { set; get; }
        public string delivery_type { set; get; }
        public decimal a { set; get; }
        public string dt { set; get; }
        public bool delivery { set; get; }
    }

    class Data
    { 
        public string pick_address_id { set; get; }
        public string address { set; get; }
        public string pick_tel { set; get; }
        public string pick_name { set; get; }
    }
}