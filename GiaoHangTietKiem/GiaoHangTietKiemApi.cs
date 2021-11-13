using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace GiaoHangTietKiem
{
    class GiaoHangTietKiemApi
    {
        //Lấy danh sách địa chỉ hàng
        public static RespronseGhtk listPick()
        {
            string _url = "/services/shipment/list_pick_add";
            string dataJson = httpRequest(urlDev + _url, "", "GET");
            //dataJson = File.ReadAllText("D:/data.txt");
            if (dataJson == "") return null;
            return parseJson<RespronseGhtk>(dataJson);
        }

        //Huỷ đơn hàng
        public static RespronseGhtk orderCancel(string label_id)
        {
            string _url = "/services/shipment/cancel/" + label_id;
            string dataJson = httpRequest(urlDev + _url, "", "POST");
            if (dataJson == "") return null;
            return parseJson<RespronseGhtk>(dataJson);
        }

        //Trạng thái đơn hàng
        public static RespronseGhtk orderInfo(string label_id)
        {
            string _url = "/services/shipment/v2/" + label_id;
            string dataJson = httpRequest(urlDev + _url, "", "GET");
            if (dataJson == "") return null;
            return parseJson<RespronseGhtk>(dataJson);
        }

        //Tính phí vận chuyển
        public static RespronseGhtk calculateFee(CalFeeRequest param)
        {
            string _url = "/services/shipment/fee?";
            _url += "pick_province" + param.pick_province;
            _url += "&pick_district" + param.pick_district;
            _url += "&province" + param.province;
            _url += "&district" + param.district;
            _url += "&address" + param.address;
            _url += "&weight" + param.weight;
            _url += "&value" + param.value;
            _url += "&transport" + param.transport;
            string dataJson = httpRequest(urlDev + _url, "", "GET");
            if (dataJson == "") return null;
            return parseJson<RespronseGhtk>(dataJson);
        }

        //Đăng đơn hàng
        public static RespronseGhtk orderAdd(OrderAddReqquest param)
        {
            string dataJson = httpRequest("/services/shipment/order/?ver=1.5", JsonConvert.SerializeObject(param), "POST");
            if (dataJson == "")
            {
                return null;
            }
            else
            {
                return parseJson<RespronseGhtk>(dataJson);
            }
        }

        private const string token = "35042506a888ba0154938b31c49994663E945275";
        private const string url = "https://services.giaohangtietkiem.vn/";
        private const string urlDev = "https://dev.ghtk.vn/";
        public static string httpRequest(string _url, string data, string method)
        {
            HttpWebRequest http = (HttpWebRequest)WebRequest.Create(urlDev + _url);
            http.Headers.Add("token", token);
            http.ContentType = "application/json; charset=utf-8";
            http.ProtocolVersion = HttpVersion.Version11;
            http.Method = method;
            if (data != "")
            {
                using (StreamWriter writer = new StreamWriter(http.GetRequestStream()))
                {
                    writer.Write(data);
                }
            }

            try
            {
                using (StreamReader reader = new StreamReader(http.GetResponse().GetResponseStream()))
                {
                    data = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                data = "";
            }
            return data;
        }

        private static T parseJson<T> (string data)
        {
            JsonSerializer s = new JsonSerializer();
            return s.Deserialize<T>(new JsonTextReader(new StringReader(data)));
        }
    }
}
