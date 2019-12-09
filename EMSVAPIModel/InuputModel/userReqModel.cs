using System;
using System.Collections.Generic;
using System.Text;

namespace EMSVAPIModel.InuputModel
{
    public class userReqModel
    { 
    public long SiteId { set; get; }
    public long StackId { set; get; }
    public long ParamId { set; get; }
    public long UserId { set; get; }
        public long VendorSiteId {set; get; }
    }
}
