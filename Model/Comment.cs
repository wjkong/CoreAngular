using System;

namespace Konger.CoreAngular.Model
{
    public class Feedback
    {
        private string _url;

        public int Id { set; get; }
        public string FullText { set; get; }
        public string Description { set; get; }
        public int ParentId { set; get; }
        public int CustID { set; get; }
        public DateTime TimeCreated { set; get; }
        public DateTime TimeUpdated { set; get; }
        public string Type { set; get; }


        public string Url
        {
            set
            {
                _url = value;

                if (!string.IsNullOrEmpty(_url) && _url == "http://apiexpert.net/")
                    _url = "http://apiexpert.net/Default.aspx";
            }

            get
            {
                return _url;
            }
        }
    }

    public class SiteStat
    {
        public int TotalLike { get; set; }
        public int TotalDislike { get; set; }
        public int TotalComment { get; set; }
        public string ErrorMeg { get; set; }
    }

    public class ParamJob
    {
        public string Query { get; set; }
        public string Country { get; set; }
        //public string State { get; set; }

        //public string City { get; set; }
        //public string StartIndex { get; set; }
        //public string PageSize { get; set; }
        //public string Sort { get; set; }
        //public string Radius { get; set; }

        //public string SiteType { get; set; }
        //public string JobType { get; set; }
        //public string FromAge { get; set; }
        //public string UserIp { get; set; }
        //public string UserAgent { get; set; }
    }

    public class ParamBusiness
    {
        public string Term { get; set; }
        public string Location { get; set; }
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public int Radius { get; set; }
    }


    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
    }
}
